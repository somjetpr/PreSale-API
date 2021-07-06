using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class PreSaleModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string SoldTo { get; set; }
        public string Dealer { get; set; }
        public string BagsCombination { get; set; }

        public string MaterialID { get; set; }
        public string MaterialDescription { get; set; }
        public string ProductName { get; set; }
        public int DomesticExport { get; set; }
        public string IndustryType { get; set; }
        public string Layers { get; set; }
        public string ProHierarchy { get; set; }
        public string UnitUsedMonth { get; set; }
        public string Color { get; set; }
        public string BagType { get; set; }
        public string FoldingDirection { get; set; }
        public int ValveType { get; set; }
        public string ValveInside { get; set; }
        public int ValveDept { get; set; }
        public int ValveWidth { get; set; }
        public int ValveLength { get; set; }
        public string ValvePV { get; set; }
        public string ValvePT { get; set; }

        public string Width { get; set; }
        public string Length { get; set; }
        public string Bottom { get; set; }
        public int Glue { get; set; }
        public string Gear { get; set; }
        public string PaperPage { get; set; }
        public string PatchTapeWidth { get; set; }
        public int PatchTapeLength { get; set; }
        public string BagEarType { get; set; }
        public int PEWidth { get; set; }
        public int PELength { get; set; }
        public string PELaminate { get; set; }
        public int PEThickness { get; set; }
        public string Lamination { get; set; }
        public string PlasticType { get; set; }

        public string Packing { get; set; }
        public int PackQty { get; set; }
        public int PalletQty { get; set; }
        public string BagCompression { get; set; }
        public string Perforate { get; set; }
        public string ShipingMark { get; set; }
        public string BagPatternPallet { get; set; }
        public string SpecialSpec { get; set; }

        public double Tube { get; set; }
        public double Waste { get; set; }
        public double NetWeight { get; set; }
        public double ListPrice { get; set; }

        public double RMCost { get; set; }
    }
}
