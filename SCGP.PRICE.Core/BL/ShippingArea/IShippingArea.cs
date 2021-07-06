using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.ShippingArea
{
    public interface IShippingArea : IBaseBLL
    {
        Task<List<pr_shipping_area>> Get();
        Task<List<ShippingAreaModel>> GetShipAreaByVenderId(string KeyVender);
        Task<pr_shipping_area> Get(int Id);
        Task<BagPriceCalculate> GetShipAreaCalculate(ConversionCostModel conversionCost);
        Task<pr_shipping_area> Add(pr_shipping_area area);
        Task<bool> Update(pr_shipping_area area);
        Task<bool> Delete(int Id);
    }
}
