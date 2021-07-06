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
    public class UserRole : BaseBLL, IUserRole
    {
        private readonly IEfRepository<pr_role> roleRepository;
        private readonly IDbConnection dbConnection;
        public UserRole(IEfRepository<pr_role> _roleRepository,
                             IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
            roleRepository = _roleRepository;
        }

        public async Task<List<UserRoleModel>> Get(string Key)
        {
            var roleQuery = roleRepository.Table.Where(x => x.isActive);
            if (!string.IsNullOrWhiteSpace(Key))
                roleQuery = roleQuery.Where(x => x.name == Key);

            var roles = await roleQuery.Select(s => new UserRoleModel
            {
                RoleId = s.Id,
                RoleName = s.name
            }).ToListAsync();

            return roles;
        }
        public async Task<UserRoleModel> Get(int RoleId)
        {
            var roleQuery = roleRepository.Table.Where(x => x.Id == RoleId);

            var userRole = roleQuery.Select(s => new UserRoleModel
            {
                RoleId = s.Id,
                RoleName = s.name
            });
            return await userRole.FirstOrDefaultAsync();
        }

        public async Task<pr_role> Add(UserRoleModel role)
        {
            var _role = await roleRepository.GetAsync(x => x.isActive && x.Id == role.RoleId);
            if (_role.Any())
                throw new Exception("Role Name is duplicate");

            var newRole = new pr_role
            {
                name = role.RoleName,
                created_by = UserName,
                updated_by = UserName
            };
            await roleRepository.AddAsync(newRole);
            return newRole;
        }
        public async Task<bool> Update(UserRoleModel role)
        {
            var _role = await roleRepository.GetAsync(x => x.isActive && x.Id == role.RoleId);
            if (!_role.Any())
                throw new Exception("Not found Role");

            var userRole = _role.FirstOrDefault();
            userRole.name = role.RoleName;
            userRole.isActive = true;
            userRole.updated_date = DateTime.Now;
            userRole.updated_by = UserName;
            return await roleRepository.UpdateAsync(userRole);
        }

    }
}
