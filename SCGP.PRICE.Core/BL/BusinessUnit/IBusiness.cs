using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.BusinessUnit
{
    public interface IBusiness : IBaseBLL
    {
        Task<List<BusinessUnitModel>> Get(string key);
        Task<BusinessUnitModel> Get(int user_id);
        Task<pr_business_unit> Add(BusinessUnitModel user);
        Task<bool> Update(BusinessUnitModel user);
    }
}
