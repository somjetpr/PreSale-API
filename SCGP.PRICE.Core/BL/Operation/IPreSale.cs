using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.Operation
{

    public interface IPreSale : IBaseBLL
    {
        Task<PricingSingleModel> PricingCalculate(ProductPriceCalSingleModel priceCalc);
        Task<PricingModel> PricingCalculate(ProductPriceCalModel priceCalc);
        //Task<List<PricingModel>> PricingCalculate(List<ProductPriceCalModel> priceCalc);
        Task<BagPriceCalculate> ConversionCost(ConversionCostModel conversionCost);
        Task<PreSaleView> Add(PreSaleView preSale);
        Task<PreSaleView> Update(PreSaleView preSale);
    }
    
}
