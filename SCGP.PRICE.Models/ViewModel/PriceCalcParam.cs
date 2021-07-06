//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;


//namespace SCGP.PRICE.Models.ViewModel
//{
//    public class PriceCalcParam
//    {
//        public string Vender { get; set; }
//        public string RMGroup { get; set; }
//        public Productdetail product { get; set; }
        
//        public List<FormulaModel> formulas { get; set; }

//        public PriceCalcParam()
//        {
//            formulas = new List<FormulaModel>();
//        }

//    }

//    public class FormulaModel
//    {
//        public string name { get; set; }
//        public string typecode { get; set; }
//        public string formulacode { get; set; }
//        public int group { get; set; }
//        public string detail { get; set; }

//        public List<Variable> variables { get; set; }

//        public FormulaModel()
//        {
//            variables = new List<Variable>();
//        }
//    }

//    public class Productdetail
//    {
//        public double PaperPage { get; set; }
//        public double Gear { get; set; }
//        public double Gram { get; set; }
//        public double Class { get; set; }

//        public double Tube { get; set; }
//        public double Waste { get; set; }
//        public double NetWeight { get; set; }
//        public double LP { get; set; }
//        public double RMCost { get; set; }
//        public double ValveWidth { get; set; }
//        public double ValveLength { get; set; }

//        public double PricePerPiece { get; set; }
//    }

//    public class Variable
//    {
//        public int Id { get; set; }
//        public string ColumnName { get; set; }
//    }
//}
