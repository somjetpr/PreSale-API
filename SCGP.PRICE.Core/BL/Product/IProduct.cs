using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Product
{
    public interface IProduct : IBaseBLL
    {
        Task<List<pr_product>> Get();
        Task<ProductPriceCalSingleModel> GetSingle(string KeyVender, string KeyGroupType, string ProductName, string Gram); 
        Task<ProductPriceCalModel> Get(string KeyVender, string KeyGroupType, string ProductName, string Gram);
        Task<pr_product> Add(pr_product pc);
        Task<bool> Update(pr_product pc);
        Task<bool> Delete(int productId);
        Task<int> Insert(pr_product pc);
    }
}
