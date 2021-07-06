using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class PricingModel
    {
        public int MaterialID { get; set; }
        public List<RMCostCalculate> rMCostCalculates { get; set; }
        public BagPriceCalculate bagPriceCalculate { get; set; }
        public PaperPriceCalculate PaperPriceCalculate { get; set; }
    }

    public class PricingSingleModel
    {
        public int MaterialID { get; set; }
        public RMCostCalculate rMCostCalculates { get; set; }
        public BagPriceCalculate bagPriceCalculate { get; set; }

    }

    public class RMCostCalculate
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string product_group_name { get; set; }
        public string rMField { get; set; }
        public int Grade { get; set; }
        public string product_name { get; set; }
        public double Tube { get; set; }
        public double Waste { get; set; }
        public double NetWeight { get; set; }
        public double Gram { get; set; }
        public int Layer { get; set; }
        public double Mas_ListPrice { get; set; }
        public double ListPrice { get; set; }
        public double Mas_RMCost { get; set; }
        public double RMCost { get; set; }
        public double TotalTube { get; set; }
        public double TotalWaste { get; set; }
        public double TotalNetWeight { get; set; }
        public double TotalListPrice { get; set; }
        public double TotalRMCost { get; set; }
        public double Allocation { get; set; }
        public double PaperSellPriceBathPerTon { get; set; }
        public double PaperSellPrice { get; set; }
        public double PaperAdjustPrice { get; set; }
        public double TotalPaperSellingPrice { get; set; }
        public double TotalPaperSellingPriceBathPerTon { get; set; }
        public double PricePerSheet { get; set; }
    }

    public class BagPriceCalculate
    {
        public int ProCostId { get; set; }
        public int ShipAreaId { get; set; }
        public double ProductionCost { get; set; }
        public double FreightAmount { get; set; }
        public double BagPriceLPAmount { get; set; }
        public double BagSellingPrice { get; set; }
        public double IncreaseSellingPrice { get; set; }
        public double IncreasePriceLPAmount { get; set; }
        public double SellingPriceAmount { get; set; }
        public double PercentDiffLP { get; set; }
        public double PercentDiffSellingPrice { get; set; }
        public double GrossProfitLP { get; set; }
        public double GrossProfitSellingPrice { get; set; }
        public double QtyPerTon { get; set; }
        public double BagPricePerTon { get; set; }
        public double VCAmount{ get; set; }
        public double FCAmount { get; set; }
        public double PlasticCostAmount { get; set; }
        public double LaminateAmount { get; set; }
        public double OtherAmount { get; set; }
        public double TotalProductionCost { get; set; } 
    }

    public class ProductionOptionCost
    {
        public int RecordId { get; set; }
        public int ConversionId { get; set; }
        public int ProdOptionCostId { get; set; }
        public string ProdOptionCostName { get; set; }
        public double value { get; set; }
    }

    public class PaperPriceCalculate
    {
        public double PaperSellingPriceBathPerTon { get; set; }
        public double PaperSellingPrice { get; set; }
        public double PaperAdjustPrice { get; set; }
        public double TotalPaperSellingPrice { get; set; }
        public double TotalPaperSellingPriceBathPerTon { get; set; }

    }
}
