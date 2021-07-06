using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Secure
{
    public interface IUserRole : IBaseBLL
    {
        Task<List<UserRoleModel>> Get(string key);
        Task<UserRoleModel> Get(int user_id);
        Task<pr_role> Add(UserRoleModel user);
        Task<bool> Update(UserRoleModel user);
    }
}
