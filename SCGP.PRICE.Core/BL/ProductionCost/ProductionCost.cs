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
using System.Data;
using Dapper;
using SCGP.PRICE.Models.ViewModel;
using SCGP.PRICE.Core.BL.Operation.Extension;

namespace SCGP.PRICE.Core.BL.ProductionCost
{
    public class ProductionCost : BaseBLL, IProductionCost
    {
        private readonly IEfRepository<pr_production_cost> costRepository;
        private readonly IEfRepository<pr_production_option_cost> optioncostRepository;
        private readonly IEfRepository<pr_formula_group> formulagroupRepository;
        private readonly IEfRepository<pr_formula> formulaRepository;
        private readonly IEfRepository<pr_formula_variable> variableRepository;
        private readonly IDbConnection dbConnection;
        public ProductionCost(IEfRepository<pr_production_cost> _costRepository,
                              IEfRepository<pr_production_option_cost> _optioncostRepository,
                              IEfRepository<pr_formula_group> _formulagroupRepository,
                              IEfRepository<pr_formula> _formulaRepository,
                              IEfRepository<pr_formula_variable> _variableRepository,
                              IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            costRepository = _costRepository;
            optioncostRepository = _optioncostRepository;
            formulagroupRepository = _formulagroupRepository;
            formulaRepository = _formulaRepository;
            variableRepository = _variableRepository;
        }

        public async Task<List<pr_production_cost>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_production_cost";
                var costs = await dbConnection.QueryAsync<pr_production_cost>(
                    sql);

                return costs.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BagPriceCalculate> CostCalculate(ConversionCostModel conversionCost)
        {

            CostModel costModel = new CostModel();
            var costQuery = costRepository.Table
                                 .Where(x => x.isActive)
                                 .Include(x => x.bagOftype)
                                 .Include(x => x.formula)
                                 .Include(x => x.formula.formulagroup)
                                 .Include(x => x.formula.formula_variables).AsQueryable();

            if (conversionCost.ProCostId != 0)
                costQuery = costQuery.Where(x => x.Id == conversionCost.ProCostId).AsQueryable();
            if (conversionCost.typeofbagId != 0)
                costQuery = costQuery.Where(x => x.bagOftype.Id == conversionCost.typeofbagId).AsQueryable();

            if (!costQuery.Any())
                throw new Exception("Not found Cost");

            var formulaQuery = formulaRepository.Table
              .Where(x => x.isActive)
              .Include(x => x.formulagroup)
              .Include(x => x.formula_variables).AsQueryable();

            if (formulaQuery.Any())
                formulaQuery = formulaQuery.Where(x => x.name == "Conversion Cost").AsQueryable();

            var formulas = formulaQuery.Select(s => new FormulaCal
            {
                formula_group_name = s.formulagroup.name,
                formula_name = s.name,
                detail = s.detail,
                variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
            }).ToList();

            var costPriceCal = costQuery.Select(s => new ConversionCostModel
            {
                CostName = s.name,
                Calculate = new CalculateCostModel
                {
                    CostPrice = Convert.ToDouble(s.price),
                    Freight = conversionCost.Calculate.Freight,
                    QtyForwardingTrip = conversionCost.Calculate.QtyForwardingTrip,
                    TotalLP = conversionCost.Calculate.TotalLP,
                    TotalRMCost = conversionCost.Calculate.TotalRMCost,
                    TotalProductionCost = conversionCost.Calculate.TotalProductionCost,
                    PercentIncrease = conversionCost.Calculate.PercentIncrease,
                    PricePerSheet = conversionCost.Calculate.PricePerSheet,
                    QtyPerTon = conversionCost.Calculate.QtyPerTon,
                },
                formulas = formulas,
            }).FirstOrDefault();
        
            PriceCalculator calculator = new PriceCalculator();
            var res = calculator.ConverCost(costPriceCal);

            return res;
        }

        public async Task<BagPriceCalculate> OptionCostCalculate(ConversionCostModel conversionCost)
        {

            CostModel costModel = new CostModel();
            var optioncostQuery = optioncostRepository.Table
                                 .Where(x => x.isActive)
                                 .Include(x => x.formula).AsQueryable();

            if (conversionCost.ProCostId != 0)
                optioncostQuery = optioncostQuery.Where(x => x.Id == conversionCost.ProCostId).AsQueryable();
            if (!string.IsNullOrWhiteSpace(conversionCost.Vender))
                optioncostQuery = optioncostQuery.Where(x => x.vender_Id == conversionCost.Vender).AsQueryable();

            if (!optioncostQuery.Any())
                throw new Exception("Not found Option Cost");

            var formulaQuery = formulaRepository.Table
              .Where(x => x.isActive)
              .Include(x => x.formulagroup)
              .Include(x => x.formula_variables).AsQueryable();

            var optionCostByformula = optioncostQuery.FirstOrDefault();
            if (formulaQuery.Any())
                formulaQuery = formulaQuery.Where(x => x.Id == optionCostByformula.formula.Id).AsQueryable();

            var formulas = formulaQuery.Select(s => new FormulaCal
            {
                formula_group_name = s.formulagroup.name,
                formula_name = s.name,
                detail = s.detail,
                variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
            }).ToList();

            var costPriceCal = optioncostQuery.Select(s => new ConversionCostModel
            {
                CostName = s.name,
                Calculate = new CalculateCostModel
                {
                    CostPrice = Convert.ToDouble(s.cost_price),
                },
                formulas = formulas,
            }).FirstOrDefault();

            PriceCalculator calculator = new PriceCalculator();
            var res = calculator.ConverCost(costPriceCal);

            return res;
        }
        public async Task<List<CostModel>> GetCostByVenderId(string KeyVender)
        {
            var costQuery = costRepository.Table.Where(x => x.isActive).Include(x => x.bagOftype).AsQueryable();
            string[] costtype = { "VC", "FC"};
            if (!string.IsNullOrWhiteSpace(KeyVender))
                costQuery = costQuery.Where(x => x.bagOftype.group == KeyVender && costtype.Contains(x.name)).AsQueryable();

            if (!costQuery.Any())
                throw new Exception("Not found Cost");

            var cost = costQuery.Select(s => new CostModel
            {
                Id = s.Id,
                Costname = s.name,
                priceCost = s.price,
            });

            return await cost.ToListAsync();
        }

        public async Task<List<CostModel>> GetCostByTypeBagId(int KeyTypeOfBag)
        {
            var costQuery = costRepository.Table.Where(x => x.isActive).Include(x => x.bagOftype).AsQueryable();

            if (KeyTypeOfBag != 0)
                costQuery = costQuery.Where(x => x.bagOftype.Id == KeyTypeOfBag).AsQueryable();

            if (!costQuery.Any())
                throw new Exception("Not found Cost");

            var cost = costQuery.Select(s => new CostModel
            {
                Id = s.Id,
                Costname = s.name,
                priceCost = s.price,
            });

            return await cost.ToListAsync();
        }

        public async Task<List<pr_production_option_cost>> GetOptionCostByVenderId(string KeyVender)
        {

            var costQuery = optioncostRepository.Table.Where(x => x.isActive).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyVender))
                costQuery = costQuery.Where(x => x.vender_Id == KeyVender).AsQueryable();

            if (!costQuery.Any())
                throw new Exception("Not found Cost");

            return await costQuery.ToListAsync();
        }
        public async Task<List<pr_production_option_cost>> GetOptionCostById(int Id)
        {

            CostModel costModel = new CostModel();
            var costQuery = optioncostRepository.Table.Where(x => x.isActive).AsQueryable();

            if (Id != 0)
                costQuery = costQuery.Where(x => x.Id == Id).AsQueryable();

            if (!costQuery.Any())
                throw new Exception("Not found Cost");

            return await costQuery.ToListAsync();
        }

        public async Task<pr_production_cost> Add(pr_production_cost cost)
        {
            var _cost = await costRepository.GetAsync(x => x.isActive && x.Id == cost.Id);
            if (_cost.Any())
                throw new Exception("Cost is duplicate");

            var newCost = new pr_production_cost
            {
                name = cost.name,
                price = cost.price,
                created_by = UserName,
                updated_by = UserName
            };
            await costRepository.AddAsync(newCost);
            return newCost;
        }
        public async Task<bool> Update(pr_production_cost productionCost)
        {
            var _cost = await costRepository.GetAsync(x => x.isActive && x.Id == productionCost.Id);
            if (!_cost.Any())
                throw new Exception("Not found Cost");

            var cost = _cost.FirstOrDefault();
            cost.name = productionCost.name;
            cost.price = productionCost.price;
            cost.isActive = productionCost.isActive;
            return await costRepository.UpdateAsync(cost);
        }
        public async Task<bool> Delete(int Id)
        {
            var cost = await costRepository.FindByIdAsync(Id);
            if (cost == null)
                throw new Exception("Not found Cost");

            cost.isActive = false;
            cost.created_date = DateTime.Now;
            cost.created_by = UserName;
            return await costRepository.UpdateAsync(cost);
        }
    }
}
