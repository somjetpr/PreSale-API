using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Customer
{
    public interface ICustomer : IBaseBLL
    {
        Task<List<pr_customer>> Get();
        Task<pr_customer> Get(int cusId);
        Task<pr_customer> Add(pr_customer cus);
        Task<bool> Update(pr_customer cus);
        Task<bool> Delete(int cusId);
    }
}
