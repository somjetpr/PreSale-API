using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Secure
{
    public interface IUserAccountBL : IBaseBLL
    {
        Task<List<UserAccountModel>> Get();
        Task<List<UserAccountModel>> Get(string key);
        Task<pr_user> Add(UserAccountModel user);
        Task<UserAccountModel> Get(int user_id);
        Task<bool> Update(UserAccountModel user);
    }
}
