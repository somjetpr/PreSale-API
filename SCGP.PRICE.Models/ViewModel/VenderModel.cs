using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class VenderModel
    {
        public int Id { get; set; }
        public string group_Id { get; set; }
        public string vender_name { get; set; }
        public string type_of_bag_name { get; set; }
        public string bag_type_name { get; set; }
        public GenneralInfoCalculate infoCalculate { get; set; }
        public List<FormulaCal> formulas { get; set; }

    }

    public class GenneralInfoCalculate
    {
        public double BagWidth { get; set; }
        public double BagLength { get; set; }
        public double BagBottom { get; set; }
        public double AdjustPaper { get; set; }
    }

    public class ResponseInfoCalculate
    {
        public string vender_name { get; set; }
        public string type_of_bag_name { get; set; }
        public string bag_type_name { get; set; }
        public double PaperPage { get; set; }
        public double Gear { get; set; }
        public double PatchTapeWidth { get; set; }
        public double PatchTapeLength { get; set; }
    }

}
