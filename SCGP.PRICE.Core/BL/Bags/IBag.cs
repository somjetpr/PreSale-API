using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Bags
{
    public interface IBag : IBaseBLL
    {
        Task<List<pr_detail>> Get();
        Task<pr_detail> Get(int saleId);
        Task<List<BagModel>> Get(string KeyType);
        Task<pr_detail> Add(pr_detail detail);
        Task<bool> Update(pr_detail detail);
        Task<bool> Delete(int detailId);
    }
}
