using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class ProductPriceCalSingleModel
    {
        public int Id { get; set; }
        public string customer_code { get; set; }
        public string Vender { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string type { get; set; }
        public string product_group_name { get; set; }
        public CalculateModel Calculate { get; set; }
        public List<FormulaCal> formulas { get; set; }
        public ConversionCostModel conversion { get; set; }

        public CalculatePaperPriceModel calculatePaper { get; set; }
    }

    public class ProductPriceCalModel
    {
        public int Id { get; set; }
        public string customer_code { get; set; }
        public string Vender { get; set; }
        public List<ProductRMCost> Products { get; set; }
        public ConversionCostModel conversion { get; set; }
        public CalculatePaperPriceModel calculatePaper { get; set; }

    }

    public class ConversionCostModel
    {
        public int ProCostId { get; set; }
        public int ShipAreaId { get; set; }
        public string Customer_code { get; set; }
        public int typeofbagId { get; set; }
        public string Vender { get; set; }

        public string CostName { get; set; }
        public string ShipAreaName { get; set; }
        public CalculateCostModel Calculate { get; set; }
        public List<FormulaCal> formulas { get; set; }

    }

    public class ProductRMCost
    {
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string type { get; set; }
        public string product_group_name { get; set; }
        public string rMField { get; set; }
        public bool adjustFlag { get; set; }    
        public CalculateModel Calculate { get; set; }
        public List<FormulaCal> formulas { get; set; }

    }

    public class CalculateModel
    {
        public double PaperPage { get; set; }
        public double Gear { get; set; }
        public double Gram { get; set; }
        public double Class { get; set; }
        public double Tube { get; set; }
        public double Waste { get; set; }
        public double NetWeight { get; set; }
        public double LP { get; set; }
        public double RMCost { get; set; }
        public double ValveDept { get; set; }
        public double ValveWidth { get; set; }
        public double ValveLength { get; set; }
        public double PatchTapeWidth { get; set; }
        public double PatchTapeLength { get; set; }
        public double PEThickness { get; set; }
        public double BagsCombination { get; set; }   
        public double PricePerPiece { get; set; }
        public double GradeListPrice { get; set; }
        public double TotalListPrice { get; set; }
        public double Laminate { get; set; }
        public double Allocation { get; set; }
        public double TotalPaperSellingPrice { get; set; }
        public double PaperSellPrice { get; set; }      
        public double TotalRMCost { get; set; }
        public double TotalProductionCost { get; set; }
        public double SellingPriceAmount { get; set; }
        public double TotalPaperRoll { get; set; }
        public double PricePerSheet { get; set; }
    }
    public class CalculateCostModel
    {
        public double CostPrice { get; set; }
        public double Freight { get; set; }
        public double QtyForwardingTrip { get; set; }
        public double PercentIncrease { get; set; }        
        public double TotalLP { get; set; }
        public double TotalRMCost { get; set; }
        public double TotalProductionCost { get; set; }
        public double BagPriceLPAmount { get; set; }
        public double BagSellingPrice { get; set; }
        public double PricePerSheet { get; set; }
        public double IncreasePriceLPAmount { get; set; }
        public double IncreaseSellingPrice { get; set; }
        public double SellingPriceAmount { get; set; }
        public double QtyPerTon { get; set; }
        
    }

    public class CalculatePaperPriceModel
    {
        public CalculatePaperPrice Calculate { get; set; }
        public List<FormulaCal> formulas { get; set; }

    }

    public class CalculatePaperPrice
    {
        public double TotalPaperSellingPrice { get; set; }
        
        public double TotalTube { get; set; }
        public double TotalRMCost { get; set; }
        public double TotalProductionCost { get; set; }
        public double SellingPriceAmount { get; set; }
        public double TotalPaperRoll { get; set; }
        
    }

    public class FormulaCal
    {
        public string formula_name { get; set; }
        public string typecode { get; set; }
        public string formulacode { get; set; }
        public string formula_group_name { get; set; }
        public string detail { get; set; }
        public int seq { get; set; }
        
        public List<VariableCal> variables { get; set; }

        public FormulaCal()
        {
            variables = new List<VariableCal>();
        }

    }

    public class VariableCal
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
    }
}
