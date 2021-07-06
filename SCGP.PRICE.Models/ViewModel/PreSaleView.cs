using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class PreSaleView
    {
        public int RecordId { get; set; }
        public int Vender { get; set; }
        public int TypeOfBag { get; set; }
        public string TypeofbagName { get; set; }
        public string CustomerName { get; set; }
        public string SoldTo { get; set; }
        public int Sale { get; set; }
        public string SaleName { get; set; }
        public string BagsCombination { get; set; }
        public string MaterialID { get; set; }
        public string MaterialDescription { get; set; }
        public string ProductName { get; set; }
        public int SaleCode { get; set; }
        public string DomesticExportName { get; set; }
        public int Industry { get; set; }
        public string IndustryTypeName { get; set; }
        public int BagLayer { get; set; }
        public string ClassName { get; set; }
        public string ProHierarchy { get; set; }
        public string UnitUsedMonth { get; set; }
        public string Color { get; set; }
        public int BagType { get; set; }
        public string BagTypeName { get; set; }
        public int Waste { get; set; }
        public int BottomDirection { get; set; }
        public string FoldingDirectionName { get; set; }
        public int ValveType { get; set; }
        public string ValveTypeName { get; set; }
        public int ValveSide { get; set; }
        public string ValveOnSideName { get; set; }
        public double ValveDept { get; set; }
        public double ValveWidth { get; set; }
        public double ValveLength { get; set; }
        public double TotTube { get; set; }
        public double TotWaste { get; set; }
        public double TotNetWeight { get; set; }
        public double TotLP { get; set; }
        public double TotListPrice { get; set; }
        public double TotRMCostBathTon { get; set; }
        public double TotRMCost { get; set; }
        public double GrandTotRMCost { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Bottom { get; set; }
        public double AdjustPage { get; set; }
        public double Gear { get; set; }
        public double PaperPage { get; set; }
        public double PatchTapeWidth { get; set; }
        public double PatchTapeLength { get; set; }
        public int BagEar { get; set; }
        public string BagEarTypeName { get; set; }
        public double PEWidth { get; set; }
        public double PELength { get; set; }
        public int PELaminate { get; set; }
        public string PELaminateName { get; set; }
        public int PEThickness { get; set; }
        public string PEThicknessName { get; set; }
        public int Lamination { get; set; }
        public string LaminationName { get; set; }
        public int PEType { get; set; }
        public string PlasticTypeName { get; set; }
        public string Packing { get; set; }
        public double PackQty { get; set; }
        public double PalletQty { get; set; }
        public double PalletUnit { get; set; }
        public double ForwardingTripQty { get; set; }
        public int BagCompressionId { get; set; }
        public string BagCompressionNmae { get; set; }
        public int Perforate { get; set; }
        public string PerforateName { get; set; }
        public int ShipingMark { get; set; }
        public string ShipingMarkName { get; set; }
        public int BagPatternPallet { get; set; }
        public int Bundling { get; set; }
        
        public string BundPackName { get; set; }
        public int BagPatternPalletId { get; set; }
        public string BagPatternPalletName { get; set; }
        public string SpecialSpec { get; set; }

        public int BagProductCost { get; set; }
        public int Shiping { get; set; }
        public int VCId { get; set; }
        public int FCId { get; set; }
        public int PlasticCost { get; set; }
        public int PlasticType { get; set; }
        public double ShipingAmt { get; set; }
        public double FreightAmount { get; set; }
        public double OtherCostAmt { get; set; }
        public double TotConversion { get; set; }
        public double Increase { get; set; }
        public double CostPer1000LP { get; set; }
        public double CostPer1000SP { get; set; }
        public double IncreaseSellingPrice { get; set; }
        public double IncreaseLP { get; set; }
        public double IncreaseSP { get; set; }
        public double ProfitLossLP { get; set; }
        public double ProfitLossSP { get; set; }
        public double GrossProfitPer1000LP { get; set; }
        public double GrossProfitPer1000SP { get; set; }
        public int LaminateCostAmt { get; set; }
        public double BagPriceBahtTon { get; set; }
        public double TotPPAllocation { get; set; }
        public double TotPPSellPriceBT { get; set; }
        public double TotPPSellPrice1000PC { get; set; }
        public PaperPriceCalculate PaperPrice { get; set; }
        public List<ProductionOptionCost> OptionCosts { get; set; }
        public List<RMCostItem> Items { get; set; }
        public PreSaleView()
        {
            Items = new List<RMCostItem>();
            OptionCosts = new List<ProductionOptionCost>();
        }
    }

    public class RMCostItem
    {
        public int RecordDetailId { get; set; }
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
        public double ListPriceBT { get; set; }
        public double ListPriceB1000PC { get; set; }
        public double RMCostBT { get; set; }
        public double RMCostB1000PC { get; set; }
  
        public double Allocation { get; set; }
        public double SellPriceBT { get; set; }
        public double SellPrice1000PC { get; set; }
    }
}
