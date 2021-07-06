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

namespace SCGP.PRICE.Core.BL.Bags
{
    public class Bag : BaseBLL, IBag
    {
        private readonly IEfRepository<pr_detail_type> bagtypeRepository;
        private readonly IEfRepository<pr_detail> bagRepositoryy;
        private readonly IDbConnection dbConnection;
        public Bag(IEfRepository<pr_detail> _bagRepository,
                   IEfRepository<pr_detail_type> _bagtypeRepository,
                   IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            bagRepositoryy = _bagRepository;
            bagtypeRepository = _bagtypeRepository;
        }

        public async Task<List<pr_detail>> Get()
        {
            try
            {
                var sql = $@"SELECT * FROM pr_detail";
                var expenses = await dbConnection.QueryAsync<pr_detail>(
                    sql);

                return expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<BagModel>> Get(string KeyType)
        {

            var detailQuery = bagRepositoryy.Table
                                 .Where(x => x.isActive)
                                 .Include(x => x.pr_detail_type).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyType))
                detailQuery = detailQuery.Where(x => x.pr_detail_type.name == KeyType).AsQueryable();

            if (!detailQuery.Any())
                throw new Exception("Not found bag");

            var query = detailQuery.Select(s => new BagModel
            {
                Id = s.Id,
                code = s.code,
                name = s.name,
                typename = s.pr_detail_type.name
            });

            return await query.ToListAsync();
        }
        public async Task<pr_detail> Get(int Id)
        {
            var detailQuery = bagRepositoryy.Table.Where(x => x.Id == Id);
            if (!detailQuery.Any())
                throw new Exception("Not found bag");

            if (!detailQuery.Any())
                throw new Exception("not found bag");

            return await detailQuery.FirstOrDefaultAsync();
        }
        public async Task<pr_detail> Add(pr_detail type)
        {
            var _type = await bagRepositoryy.GetAsync(x =>  x.Id == type.Id);
            if (_type.Any())
                throw new Exception("Sale is bag");

            var newtype = new pr_detail
            {
                name = type.name
            };
            await bagRepositoryy.AddAsync(newtype);
            return newtype;
        }
        public async Task<bool> Update(pr_detail prtype)
        {
            var _type = await bagRepositoryy.GetAsync(x => x.Id == prtype.Id);
            if (!_type.Any())
                throw new Exception("Not found bag");

            var type = _type.FirstOrDefault();
            type.name = prtype.name;
            return await bagRepositoryy.UpdateAsync(type);
        }
        public async Task<bool> Delete(int Id)
        {
            var type = await bagRepositoryy.FindByIdAsync(Id);
            if (type == null)
                throw new Exception("Not found bag type");

            return await bagRepositoryy.UpdateAsync(type);
        }
    }
}
