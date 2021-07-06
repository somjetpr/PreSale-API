using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.BL.ProductionCost
{
    public interface IProductionCost : IBaseBLL
    {
        Task<List<pr_production_cost>> Get();
        Task<List<CostModel>> GetCostByTypeBagId(int KeyTypeOfBag);
        Task<List<CostModel>> GetCostByVenderId(string KeyVender);
        Task<List<pr_production_option_cost>> GetOptionCostByVenderId(string KeyVender);
        Task<BagPriceCalculate> CostCalculate(ConversionCostModel conversionCost);
        Task<BagPriceCalculate> OptionCostCalculate(ConversionCostModel conversionCost);
        Task<List<pr_production_option_cost>> GetOptionCostById(int Id);
        Task<pr_production_cost> Add(pr_production_cost cost);
        Task<bool> Update(pr_production_cost cost);
        Task<bool> Delete(int Id);
    }
}
