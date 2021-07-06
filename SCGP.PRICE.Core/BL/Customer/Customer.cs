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

namespace SCGP.PRICE.Core.BL.Customer
{
    public class Customer : BaseBLL, ICustomer
    {
        private readonly IEfRepository<pr_customer> customerRepository;

        private readonly IDbConnection dbConnection;
        public Customer(IEfRepository<pr_customer> _customerRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            customerRepository = _customerRepository;
        }

        public async Task<List<pr_customer>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_customer";
                var customer = await dbConnection.QueryAsync<pr_customer>(
                    sql);

                return customer.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<pr_customer> Get(int cusId)
        {
            var customerQuery = customerRepository.Table.Where(x => x.Id == cusId);
            if (!customerQuery.Any())
                throw new Exception("Not found customer");

            if (!customerQuery.Any(x => x.isActive))
                throw new Exception("not found customer");

            return await customerQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_customer> Add(pr_customer cus)
        {
            var _customer = await customerRepository.GetAsync(x => x.isActive && x.Id == cus.Id);
            if (_customer.Any())
                throw new Exception("customer is duplicate");

            var newCustomer = new pr_customer
            {
                customer_code = cus.customer_code,
                customer_id = cus.customer_id,
                created_by = UserName,
                updated_by = UserName
            };
            await customerRepository.AddAsync(newCustomer);
            return newCustomer;
        }
        public async Task<bool> Update(pr_customer cus)
        {
            var _customer = await customerRepository.GetAsync(x => x.isActive && x.Id == cus.Id);
            if (!_customer.Any())
                throw new Exception("Not found customer");

            var customer = _customer.FirstOrDefault();
            customer.customer_code = cus.customer_code;
            customer.customer_id = cus.customer_id;
            customer.isActive = cus.isActive;
            return await customerRepository.UpdateAsync(customer);
        }
        public async Task<bool> Delete(int cusId)
        {
            var cus = await customerRepository.FindByIdAsync(cusId);
            if (cus == null)
                throw new Exception("Not found customer");

            cus.isActive = false;
            cus.created_date = DateTime.Now;
            cus.created_by = UserName;
            return await customerRepository.UpdateAsync(cus);
        }
    }
}
