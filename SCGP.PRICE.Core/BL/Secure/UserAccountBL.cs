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

namespace SCGP.PRICE.Core.BL.Secure
{
    public class UserAccountBL : BaseBLL, IUserAccountBL
    {
        private readonly IEfRepository<pr_user> userRepository;
        private readonly IEfRepository<pr_role> roleRepository;
        private readonly IEfRepository<pr_business_unit> buRepository;

        private readonly IDbConnection dbConnection;
        public UserAccountBL(IEfRepository<pr_user> _userRepository,
                              IEfRepository<pr_role> _roleRepository,
                               IEfRepository<pr_business_unit> _buRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            userRepository = _userRepository;
            roleRepository = _roleRepository;
            buRepository = _buRepository;
        }

        public async Task<List<UserAccountModel>> Get()
        {
            var userQuery = userRepository.Table.Where(x => x.isActive).Include(x => x.pr_role).AsQueryable();

            List<UserAccountModel> userlist = new List<UserAccountModel>();

            foreach (var item in userQuery.ToList())
            {
                string subbu = string.Empty;
                string businessunit = string.Empty;

                if (!string.IsNullOrWhiteSpace(item.bu))
                {
                    string[] bus = item.bu.Split(',');
                    var buQuery = buRepository.Table.Where(x => bus.Contains(x.Id.ToString()));
                    subbu = string.Join(",", buQuery.Select(u => u.sub_bu.ToString()).ToArray());

                    var _business = buQuery
                        .GroupBy(x => x.business_unit)
                        .Select(s => new
                        {
                            business_unit = s.Key
                        }).FirstOrDefault();
                    businessunit = _business.business_unit;
                }

                var users = new UserAccountModel
                {
                    Id = item.Id,
                    Username = item.username,
                    Name = item.name,
                    RoleId = item.pr_role == null ? 0 :item.pr_role.Id,
                    RoleName = item.pr_role?.name,
                    BuId = item.bu,
                    BuName = businessunit,
                    SubBuName = subbu,
                    IsActive = item.isActive
                };

                userlist.Add(users);
            }

            return userlist;
        }

        public async Task<List<UserAccountModel>> Get(string KeyUser)
        {

            var userQuery = userRepository.Table.Where(x => x.isActive).Include(x => x.pr_role).AsQueryable();

            if (!string.IsNullOrWhiteSpace(KeyUser))
                userQuery = userQuery.Where(x => x.username == KeyUser || x.name == KeyUser || x.pr_role.name == KeyUser).AsQueryable();

            List<UserAccountModel> userlist = new List<UserAccountModel>();

            foreach (var item in userQuery.ToList())
            {
                string subbu = string.Empty;
                string businessunit = string.Empty;

                if (!string.IsNullOrWhiteSpace(item.bu))
                {
                    string[] bus = item.bu.Split(',');
                    var buQuery = buRepository.Table.Where(x => bus.Contains(x.Id.ToString()));
                    subbu = string.Join(",", buQuery.Select(u => u.sub_bu.ToString()).ToArray());

                    var _business = buQuery
                        .GroupBy(x => x.business_unit)
                        .Select(s => new
                        {
                            business_unit = s.Key
                        }).FirstOrDefault();
                    businessunit = _business.business_unit;
                }

                var user = new UserAccountModel
                {
                    Id = item.Id,
                    Username = item.username,
                    Name = item.name,
                    RoleId = item.pr_role == null ? 0 : item.pr_role.Id,
                    RoleName = item.pr_role.name,
                    BuId = item.bu,
                    BuName = businessunit,
                    SubBuName = subbu,
                    IsActive = item.isActive
                };
                userlist.Add(user);
            }

            return userlist;
        }

        public async Task<pr_user> Add(UserAccountModel user)
        {
            var _user = await userRepository.GetAsync(x => x.isActive && x.username == user.Username);
            if (_user.Any())
                throw new Exception("Username is duplicate");
            var _role = await roleRepository.Table.Where(x => x.isActive && x.Id == user.RoleId).FirstOrDefaultAsync();

            var newUser = new pr_user
            {
                name = user.Name,
                username = user.Username,
                pr_role = _role,
                bu = user.BuId,
                created_by = "1",
                updated_by = "1"
            };
            await userRepository.AddAsync(newUser);
            return newUser;
        }
        public async Task<bool> Update(UserAccountModel user)
        {
            var _user = await userRepository.GetAsync(x => x.isActive && x.Id == user.Id);
            if (!_user.Any())
                throw new Exception("Not found user");
            var _role = await roleRepository.Table.Where(x => x.isActive && x.Id == user.RoleId).FirstOrDefaultAsync();

            var userAccount = _user.FirstOrDefault();
            userAccount.name = user.Name;
            userAccount.username = user.Username;
            userAccount.pr_role = _role;
            userAccount.bu = user.BuId;
            userAccount.isActive = user.IsActive;
            return await userRepository.UpdateAsync(userAccount);
        }

        public async Task<UserAccountModel> Get(int userId)
        {
            var userQuery = userRepository.Table.Where(x => x.Id == userId);

            var user = userQuery.FirstOrDefault();
            //string[] bus = user.bu.Split(',');
            //var buQuery = buRepository.Table.Where(x => bus.Contains(x.Id.ToString()));
            //string subbu = string.Join(",", buQuery.Select(u => u.sub_bu.ToString()).ToArray());

            string subbu = string.Empty;
            string businessunit = string.Empty;

            if (!string.IsNullOrWhiteSpace(user.bu))
            {
                string[] bus = user.bu.Split(',');
                var buQuery = buRepository.Table.Where(x => bus.Contains(x.Id.ToString()));
                subbu = string.Join(",", buQuery.Select(u => u.sub_bu.ToString()).ToArray());

                var _business = buQuery
                    .GroupBy(x => x.business_unit)
                    .Select(s => new
                    {
                        business_unit = s.Key
                    }).FirstOrDefault();
                businessunit = _business.business_unit;
            }

            var usermodel = userQuery.Select(s => new UserAccountModel
            {
                Id = s.Id,
                Username = s.username,
                Name = s.name,
                RoleId = s.pr_role.Id,
                RoleName = s.pr_role.name,
                BuId = s.bu,
                SubBuName = subbu,
                BuName = businessunit,
                IsActive = s.isActive
            });
            return await usermodel.FirstOrDefaultAsync();
        }
    }
}
