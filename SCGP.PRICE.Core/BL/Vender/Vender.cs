using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SCGP.PRICE.Core.Context;
using SCGP.PRICE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SCGP.PRICE.Models.ViewModel;
using Melonsoft.SL.Core.BL.Secure;
using System.Data;
using Dapper;
using SCGP.PRICE.Core.BL.Operation.Extension;

namespace SCGP.PRICE.Core.BL.Vender
{
    public class Vender : BaseBLL, IVender
    {
        private readonly IEfRepository<pr_bag_of_type> venderRepository;
        private readonly IEfRepository<pr_formula_group> formulagroupRepository;
        private readonly IEfRepository<pr_formula> formulaRepository;
        private readonly IEfRepository<pr_formula_variable> variableRepository;
        private readonly IDbConnection dbConnection;
        public Vender(IEfRepository<pr_bag_of_type> _venderRepository,
                              IEfRepository<pr_formula_group> _formulagroupRepository,
                              IEfRepository<pr_formula> _formulaRepository,
                              IEfRepository<pr_formula_variable> _variableRepository,
                   IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            venderRepository = _venderRepository;
            formulagroupRepository = _formulagroupRepository;
            formulaRepository = _formulaRepository;
            variableRepository = _variableRepository;
        }

        public async Task<List<VenderModel>> GetVender()
        {
            try
            {
                var venderQuery = venderRepository.Table.Where(x => x.isActive && x.group == "1");
                if (!venderQuery.Any())
                    throw new Exception("Not found vender");

                var vender = venderQuery.GroupBy(g => new
                {
                    g.group,
                    g.name
                }).Select(s => new VenderModel
                {
                    group_Id = s.Key.group,
                    vender_name = s.Key.name
                });

                return vender.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<VenderModel>> GetbagsType(string groupId)
        {
            try
            {
                VenderModel info = new VenderModel();
                var venderQuery = venderRepository.Table.Where(x => x.isActive)
                                                  .Include(x => x.formulas).AsQueryable();
                if (!venderQuery.Any())
                    throw new Exception("Not found vender");

                if (!string.IsNullOrWhiteSpace(groupId))
                    venderQuery = venderQuery.Where(x => x.group == groupId).AsQueryable();

                var bagtype = venderQuery.Select(s => new VenderModel
                {
                    Id = s.Id,
                    vender_name = s.name,
                    type_of_bag_name = s.type
                });

                return bagtype.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseInfoCalculate> GetbagsTypeCalculate(VenderModel vender)
        {
            try
            {
                ResponseInfoCalculate info = new ResponseInfoCalculate();
                var venderQuery = venderRepository.Table.Where(x => x.isActive)
                                  .Include(x => x.formulas).AsQueryable();
                if (!venderQuery.Any())
                    throw new Exception("Not found vender");

                if (!string.IsNullOrWhiteSpace(vender.group_Id))
                    venderQuery = venderQuery.Where(x => x.group == vender.group_Id).AsQueryable();

                if (vender.Id != 0)
                    venderQuery = venderQuery.Where(x => x.Id == vender.Id).AsQueryable();

                var formulaQuery = formulaRepository.Table.Where(x => x.isActive)
                                                     .Include(x => x.bagOftype)
                                                     .Include(x => x.formulagroup)
                                                     .Include(x => x.formula_variables).AsQueryable();

                if (vender.Id != 0)
                    formulaQuery = formulaQuery.Where(x => x.bagOftype.Id == vender.Id).AsQueryable();

                if (!string.IsNullOrWhiteSpace(vender.bag_type_name))
                    formulaQuery = formulaQuery.Where(x => x.name == vender.bag_type_name).AsQueryable();
                else
                    formulaQuery = formulaQuery.Where(x => string.IsNullOrWhiteSpace(x.name)).AsQueryable();

                var formulas = formulaQuery.Select(s => new FormulaCal
                {
                    formula_group_name = s.formulagroup.name,
                    formula_name = s.name,
                    detail = s.detail,
                    variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
                }).ToList();

                var bagtype = venderQuery.Select(s => new VenderModel
                {
                    Id = s.Id,
                    vender_name = s.name,
                    type_of_bag_name = s.type,
                    bag_type_name = vender.bag_type_name,
                    infoCalculate = new GenneralInfoCalculate
                    {
                        BagBottom = vender.infoCalculate.BagBottom,
                        BagLength = vender.infoCalculate.BagLength,
                        BagWidth = vender.infoCalculate.BagWidth,
                        AdjustPaper = vender.infoCalculate.AdjustPaper
                    },
                    formulas = formulas
                });

                if (vender.Id != 0 || !string.IsNullOrWhiteSpace(vender.bag_type_name))
                {
                    PriceCalculator calculator = new PriceCalculator();
                    info = calculator.GenneralInfo(bagtype.FirstOrDefault());
                }

                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<pr_bag_of_type> Get(int Id)
        {
            var venderQuery = venderRepository.Table.Where(x => x.Id == Id);

            if (!venderQuery.Any())
                throw new Exception("not found vender");

            return await venderQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_bag_of_type> Add(pr_bag_of_type vender)
        {
            var _vender = await venderRepository.GetAsync(x => x.Id == vender.Id);
            if (_vender.Any())
                throw new Exception("Sale is vender");

            var newtype = new pr_bag_of_type
            {
                name = vender.name
            };
            await venderRepository.AddAsync(newtype);
            return newtype;
        }
        public async Task<bool> Update(pr_bag_of_type prtype)
        {
            var _vender = await venderRepository.GetAsync(x => x.Id == prtype.Id);
            if (!_vender.Any())
                throw new Exception("Not found vender");

            var vender = _vender.FirstOrDefault();
            vender.name = prtype.name;
            return await venderRepository.UpdateAsync(vender);
        }
        public async Task<bool> Delete(int Id)
        {
            var type = await venderRepository.FindByIdAsync(Id);
            if (type == null)
                throw new Exception("Not found vender");

            return await venderRepository.UpdateAsync(type);
        }
    }
}
