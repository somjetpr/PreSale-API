using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Vender
{
    public interface IVender : IBaseBLL
    {
        Task<pr_bag_of_type> Get(int venderId);
        Task<List<VenderModel>> GetVender();
        Task<List<VenderModel>> GetbagsType(string groupId);
        Task<ResponseInfoCalculate> GetbagsTypeCalculate(VenderModel vender);
        Task<pr_bag_of_type> Add(pr_bag_of_type vender);
        Task<bool> Update(pr_bag_of_type vender);
        Task<bool> Delete(int venderId);
    }
}
