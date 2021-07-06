using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Sale
{
    public interface ISale : IBaseBLL
    {
        Task<List<pr_sale>> Get();
        Task<pr_sale> Get(int saleId);
        Task<pr_sale> Add(pr_sale sale);
        Task<bool> Update(pr_sale sale);
        Task<bool> Delete(int productId);
    }
}
