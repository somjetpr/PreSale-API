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

namespace SCGP.PRICE.Core.BL.Sale
{
    public class Sale : BaseBLL, ISale
    {
        private readonly IEfRepository<pr_sale> saleRepository;

        private readonly IDbConnection dbConnection;
        public Sale(IEfRepository<pr_sale> _saleRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            saleRepository = _saleRepository;
        }

        public async Task<List<pr_sale>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_sale";
                var sales = await dbConnection.QueryAsync<pr_sale>(
                    sql);

                return sales.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<pr_sale> Get(int saleId)
        {
            var saleQuery = saleRepository.Table.Where(x => x.Id == saleId);
            if (!saleQuery.Any())
                throw new Exception("Not found sale");

            if (!saleQuery.Any(x => x.isActive))
                throw new Exception("not found sale");

            return await saleQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_sale> Add(pr_sale sale)
        {
            var _sale = await saleRepository.GetAsync(x => x.isActive && x.Id == sale.Id);
            if (_sale.Any())
                throw new Exception("Sale is duplicate");

            var newSale = new pr_sale
            {
                first_name = sale.first_name,
                last_name = sale.last_name,
                created_by = UserName,
                updated_by = UserName
            };
            await saleRepository.AddAsync(newSale);
            return newSale;
        }
        public async Task<bool> Update(pr_sale pcSale)
        {
            var _sale = await saleRepository.GetAsync(x => x.isActive && x.Id == pcSale.Id);
            if (!_sale.Any())
                throw new Exception("Not found Sale");

            var sale = _sale.FirstOrDefault();
            sale.first_name = pcSale.first_name;
            sale.last_name = pcSale.last_name;
            sale.isActive = pcSale.isActive;
            return await saleRepository.UpdateAsync(sale);
        }
        public async Task<bool> Delete(int saleId)
        {
            var sale = await saleRepository.FindByIdAsync(saleId);
            if (sale == null)
                throw new Exception("Not found product");

            sale.isActive = false;
            sale.created_date = DateTime.Now;
            sale.created_by = UserName;
            return await saleRepository.UpdateAsync(sale);
        }
    }
}
