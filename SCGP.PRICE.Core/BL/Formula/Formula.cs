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

namespace SCGP.PRICE.Core.BL.Formula
{
    public class Formula : BaseBLL, IFormula
    {
        private readonly IEfRepository<pr_formula> formulaRepository;

        private readonly IDbConnection dbConnection;
        public Formula(IEfRepository<pr_formula> _formulaRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            formulaRepository = _formulaRepository;
        }

        public async Task<List<pr_formula>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_formula";
                var expenses = await dbConnection.QueryAsync<pr_formula>(
                    sql);

                return expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<pr_formula> Get(int formulaId)
        {
            var formulaQuery = formulaRepository.Table.Where(x => x.Id == formulaId);
            if (!formulaQuery.Any())
                throw new Exception("Not found formula");

            if (formulaQuery.Any(x => x.isActive))
                throw new Exception("not found formula");

            return await formulaQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_formula> Add(pr_formula formula)
        {

            var _formula = await formulaRepository.GetAsync(x => x.isActive && x.Id == formula.Id);
            if (_formula.Any())
                throw new Exception("formula is duplicate");

            var newformula = new pr_formula
            {
                formula_code = formula.formula_code,
                name = formula.name,
                created_by = UserName,
                updated_by = UserName
            };
            await formulaRepository.AddAsync(newformula);
            return newformula;
        }
        public async Task<bool> Update(pr_formula pcFormula)
        {
            var _formula = await formulaRepository.GetAsync(x => x.isActive && x.Id == pcFormula.Id);
            if (!_formula.Any())
                throw new Exception("Not found product");

            var formula = _formula.FirstOrDefault();
            formula.formula_code = pcFormula.formula_code;
            return await formulaRepository.UpdateAsync(formula);
        }
        public async Task<bool> Delete(int formulaId)
        {
            var formula = await formulaRepository.FindByIdAsync(formulaId);
            if (formula == null)
                throw new Exception("Not found formula");

            formula.isActive = false;
            formula.created_date = DateTime.Now;
            formula.created_by = UserName;
            return await formulaRepository.UpdateAsync(formula);
        }
    }
}
