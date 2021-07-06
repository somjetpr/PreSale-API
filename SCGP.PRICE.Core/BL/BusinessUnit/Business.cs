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

namespace SCGP.PRICE.Core.BL.BusinessUnit
{
    public class Business : BaseBLL, IBusiness
    {
        private readonly IEfRepository<pr_business_unit> BusinessRepository;
        private readonly IDbConnection dbConnection;
        public Business(IEfRepository<pr_business_unit> _BusinessRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            BusinessRepository = _BusinessRepository;
        }

        public async Task<List<BusinessUnitModel>> Get(string Key)
        {
            var busQuery = BusinessRepository.Table.Where(x => x.isActive);
            if (!string.IsNullOrWhiteSpace(Key))
                busQuery = busQuery.Where(x => x.business_unit == Key);

            var bus = await busQuery.Select(s => new BusinessUnitModel
            {
                BusinessUnitId = s.Id,
                BusinessUnit = s.business_unit,
                SubBU = s.sub_bu
            }).ToListAsync();

            return bus;
        }
        public async Task<BusinessUnitModel> Get(int BusinessId)
        {
            var busQuery = BusinessRepository.Table.Where(x => x.Id == BusinessId);

            var business = busQuery.Select(s => new BusinessUnitModel
            {
                BusinessUnitId = s.Id,
                BusinessUnit = s.business_unit,
                SubBU = s.sub_bu
            });
            
            return await business.FirstOrDefaultAsync();
        }

        public async Task<pr_business_unit> Add(BusinessUnitModel business)
        {
            var _role = await BusinessRepository.GetAsync(x => x.isActive && x.Id == business.BusinessUnitId);
            if (_role.Any())
                throw new Exception("business Name is duplicate");

            var newBusiness = new pr_business_unit
            {
                business_unit = business.BusinessUnit,
                sub_bu = business.SubBU,
                isActive = true,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
                created_by = UserName,
                updated_by = UserName
            };
            await BusinessRepository.AddAsync(newBusiness);
            return newBusiness;
        }
        public async Task<bool> Update(BusinessUnitModel business)
        {
            var _business = await BusinessRepository.GetAsync(x => x.isActive && x.Id == business.BusinessUnitId);
            if (!_business.Any())
                throw new Exception("Not found business");

            var businessUnit = _business.FirstOrDefault();
            businessUnit.business_unit = business.BusinessUnit;
            businessUnit.sub_bu = business.SubBU;
            businessUnit.isActive = true;
            businessUnit.updated_date = DateTime.Now;
            businessUnit.updated_by = UserName;
            return await BusinessRepository.UpdateAsync(businessUnit);
        }

    }
}
