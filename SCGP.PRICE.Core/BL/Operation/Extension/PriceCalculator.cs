using org.mariuszgromada.math.mxparser;
using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCGP.PRICE.Core.BL.Operation.Extension
{
    public class PriceCalculator
    {
        public PriceCalculator()
        {
            Initialize();
        }
        private void Initialize()
        {
            load_Variable();
        }
        private void load_Variable()
        {
        }
        public ResponseInfoCalculate GenneralInfo(VenderModel vender)
        {
            ResponseInfoCalculate preSale = new ResponseInfoCalculate();
            preSale.vender_name = vender.vender_name;
            preSale.bag_type_name = vender.bag_type_name;
            preSale.type_of_bag_name = vender.type_of_bag_name;

            foreach (var item in vender.formulas)
            {
                switch (item.formula_group_name)
                {
                    case "PaperPage":
                        preSale.PaperPage = evalInfo(item, vender);
                        break;
                    case "Gear":
                        preSale.Gear = evalInfo(item, vender);
                        break;
                    case "PatchTapeWidth":
                        preSale.PatchTapeWidth = evalInfo(item, vender);
                        break;
                    case "PatchTapeLength":
                        preSale.PatchTapeLength = evalInfo(item, vender);
                        break;
                    default:
                        preSale.PaperPage = 0; preSale.Gear = 0;
                        break;
                }
            }

            return preSale;
        }
        public PricingModel PreSaleEvaluate(ProductPriceCalModel priceCalc)
        {
            PricingModel pricing = new PricingModel();
            pricing.rMCostCalculates = new List<RMCostCalculate>();
            foreach (var prodpricecalc in priceCalc.Products)
            {
                RMCostCalculate preSale = new RMCostCalculate();
                preSale.product_group_name = prodpricecalc.product_group_name;
                preSale.product_name = prodpricecalc.product_name;
                preSale.Mas_ListPrice = prodpricecalc.Calculate.LP;
                preSale.Mas_RMCost = prodpricecalc.Calculate.RMCost;
                preSale.Gram = prodpricecalc.Calculate.Gram;
                preSale.PricePerSheet = prodpricecalc.Calculate.PricePerSheet;
                preSale.rMField = prodpricecalc.rMField;
                foreach (var item in prodpricecalc.formulas)
                {
                    switch (item.formula_group_name)
                    {
                        case "Tube":
                            preSale.Tube = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "Waste":
                            prodpricecalc.Calculate.Tube = preSale.Tube;
                            preSale.Waste = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "NetWeight":
                            prodpricecalc.Calculate.Tube = preSale.Tube;
                            prodpricecalc.Calculate.Waste = preSale.Waste;
                            preSale.NetWeight = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "LP":
                            prodpricecalc.Calculate.NetWeight = preSale.NetWeight;
                            preSale.ListPrice = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "RMCost":
                            preSale.RMCost = eval(item, priceCalc, prodpricecalc);
                            break;
                        //case "Allocation":
                        //    prodpricecalc.Calculate.GradeListPrice = preSale.ListPrice;
                        //    preSale.Allocation = Math.Round(eval(item, priceCalc, prodpricecalc));
                        //    break;
                        //case "PaperSellPrice":
                        //    prodpricecalc.Calculate.Allocation = preSale.Allocation;
                        //    preSale.PaperSellPrice = Math.Round(eval(item, priceCalc, prodpricecalc));
                        //    break;
                        //case "PaperSellPriceBathPerTon":
                        //    prodpricecalc.Calculate.PaperSellPrice = preSale.PaperSellPrice;
                        //    preSale.PaperSellPriceBathPerTon = Math.Round(eval(item, priceCalc, prodpricecalc));
                        //    break;
                        //case "PaperAdjustPrice":
                        //    preSale.PaperAdjustPrice = Math.Round(eval(item, priceCalc, prodpricecalc));
                        //    break;
                        default:
                            break;
                    }

                }

                pricing.rMCostCalculates.Add(preSale);
            }

            return pricing;
        }
        public PricingModel PreSalePaperEvaluate(ProductPriceCalModel priceCalc)
        {
            PricingModel pricing = new PricingModel();
            pricing.rMCostCalculates = new List<RMCostCalculate>();

            foreach (var prodpricecalc in priceCalc.Products)
            {
                RMCostCalculate preSale = new RMCostCalculate();
                preSale.product_group_name = prodpricecalc.product_group_name;
                preSale.product_name = prodpricecalc.product_name;
                preSale.Mas_ListPrice = prodpricecalc.Calculate.LP;
                preSale.Mas_RMCost = prodpricecalc.Calculate.RMCost;
                preSale.Gram = prodpricecalc.Calculate.Gram;
                preSale.rMField = prodpricecalc.rMField;
                foreach (var item in prodpricecalc.formulas)
                {
                    switch (item.formula_group_name)
                    {
                        case "Tube":
                            preSale.Tube = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "Waste":
                            prodpricecalc.Calculate.Tube = preSale.Tube;
                            preSale.Waste = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "NetWeight":
                            prodpricecalc.Calculate.Tube = preSale.Tube;
                            prodpricecalc.Calculate.Waste = preSale.Waste;
                            preSale.NetWeight = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "LP":
                            prodpricecalc.Calculate.NetWeight = preSale.NetWeight;
                            preSale.ListPrice = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "RMCost":
                            preSale.RMCost = eval(item, priceCalc, prodpricecalc);
                            break;
                        case "Allocation":
                            prodpricecalc.Calculate.GradeListPrice = preSale.ListPrice;
                            preSale.Allocation = Math.Round(eval(item, priceCalc, prodpricecalc));
                            break;
                        case "PaperSellPrice":
                            prodpricecalc.Calculate.Allocation = preSale.Allocation;
                            preSale.PaperSellPrice = Math.Round(eval(item, priceCalc, prodpricecalc));
                            break;
                        case "PaperSellPriceBathPerTon":
                            prodpricecalc.Calculate.PaperSellPrice = preSale.PaperSellPrice;
                            preSale.PaperSellPriceBathPerTon = Math.Round(eval(item, priceCalc, prodpricecalc));
                            break;
                        case "PaperAdjustPrice":
                            preSale.PaperAdjustPrice = Math.Round(eval(item, priceCalc, prodpricecalc));
                            break;
                        default:
                            break;
                    }
                }

                pricing.rMCostCalculates.Add(preSale);
            }

            return pricing;
        }
        public PaperPriceCalculate PaperPriceEvaluate(CalculatePaperPriceModel calculatePaper)
        {
            PaperPriceCalculate preSale = new PaperPriceCalculate();
            foreach (var item in calculatePaper.formulas)
            {
                switch (item.formula_group_name)
                {
                    case "TotalPaperSellingPrice":
                        preSale.TotalPaperSellingPrice = evalPaperPrice(item, calculatePaper);
                        break;
                    case "TotalPaperSellingPriceBathPerTon":
                        calculatePaper.Calculate.TotalPaperSellingPrice = preSale.TotalPaperSellingPrice;
                        preSale.TotalPaperSellingPriceBathPerTon = evalPaperPrice(item, calculatePaper);
                        break;
                    case "PaperSellingPriceBathPerTon":
                        preSale.PaperSellingPriceBathPerTon = evalPaperPrice(item, calculatePaper);
                        break;
                    case "PaperSellingPrice":
                        preSale.PaperSellingPrice = evalPaperPrice(item, calculatePaper);
                        break;
                    default:
                        break;
                }
            }

            return preSale;
        }
        public PricingSingleModel PreSaleEvaluate(ProductPriceCalSingleModel priceCalc)
        {
            PricingSingleModel pricing = new PricingSingleModel();
            pricing.rMCostCalculates = new RMCostCalculate();

            RMCostCalculate preSale = new RMCostCalculate();
            preSale.product_group_name = priceCalc.product_group_name;
            preSale.product_name = priceCalc.product_name;
            preSale.Mas_ListPrice = priceCalc.Calculate.LP;
            preSale.Mas_RMCost = priceCalc.Calculate.RMCost;
            preSale.Gram = priceCalc.Calculate.Gram;

            foreach (var item in priceCalc.formulas)
            {

                switch (item.formula_group_name)
                {
                    case "Tube":
                        preSale.Tube = eval(item, priceCalc);
                        break;
                    case "Waste":
                        priceCalc.Calculate.Tube = preSale.Tube;
                        preSale.Waste = eval(item, priceCalc);
                        break;
                    case "NetWeight":
                        priceCalc.Calculate.Tube = preSale.Tube;
                        priceCalc.Calculate.Waste = preSale.Waste;
                        preSale.NetWeight = eval(item, priceCalc);
                        break;
                    case "LP":
                        priceCalc.Calculate.NetWeight = preSale.NetWeight;
                        preSale.ListPrice = eval(item, priceCalc);
                        break;
                    case "RMCost":
                        preSale.RMCost = eval(item, priceCalc);
                        break;
                    case "Allocation":
                        preSale.Allocation = eval(item, priceCalc);
                        break;
                    default:
                        break;
                }
            }

            pricing.rMCostCalculates = preSale;

            return pricing;
        }
        public double evalInfo(FormulaCal formula, VenderModel vender)
        {
            Expression e = new Expression(formula.detail);

            Type myClassType = vender.infoCalculate.GetType();
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (var variableItem in formula.variables)
            {
                foreach (PropertyInfo property in properties)
                {
                    double value = (double)property.GetValue(vender.infoCalculate, null);
                    if (variableItem.ColumnName.Contains(property.Name))
                        e.addArguments(new Argument(variableItem.ColumnName, value));
                }
            }


            double result = 0;
            if (!Double.IsNaN(e.calculate()))
                result = Math.Round(e.calculate(), 2);

            return result;
        }
        public BagPriceCalculate ConverCost(ConversionCostModel conversionCost)
        {
            BagPriceCalculate preSale = new BagPriceCalculate();
            foreach (var item in conversionCost.formulas)
            {
                switch (item.formula_group_name)
                {
                    case "ProductionCost":
                        preSale.ProductionCost = evalCost(item, conversionCost);
                        break;
                    case "FreightAmount":
                        preSale.FreightAmount = evalCost(item, conversionCost);
                        break;
                    case "BagPriceLPAmount":
                        preSale.BagPriceLPAmount = evalCost(item, conversionCost);
                        break;
                    case "BagSellingPrice":
                        preSale.BagSellingPrice = evalCost(item, conversionCost);
                        break;
                    case "IncreasePriceLPAmount":
                        conversionCost.Calculate.BagPriceLPAmount = preSale.BagPriceLPAmount;
                        preSale.IncreasePriceLPAmount = evalCost(item, conversionCost);
                        break;
                    case "IncreaseSellingPrice":
                        conversionCost.Calculate.BagSellingPrice = preSale.BagSellingPrice;
                        preSale.IncreaseSellingPrice = evalCost(item, conversionCost);
                        break;
                    case "SellingPriceAmount":
                        preSale.SellingPriceAmount = evalCost(item, conversionCost);
                        break;
                    case "PercentDiffLP":
                        conversionCost.Calculate.IncreasePriceLPAmount = preSale.IncreasePriceLPAmount;
                        preSale.PercentDiffLP = evalCost(item, conversionCost);
                        break;
                    case "PercentDiffSellingPrice":
                        conversionCost.Calculate.IncreaseSellingPrice = preSale.IncreaseSellingPrice;
                        preSale.PercentDiffSellingPrice = evalCost(item, conversionCost);
                        break;
                    case "GrossProfitLP":
                        preSale.GrossProfitLP = evalCost(item, conversionCost);
                        break;
                    case "GrossProfitSellingPrice":
                        conversionCost.Calculate.SellingPriceAmount = preSale.SellingPriceAmount;
                        preSale.GrossProfitSellingPrice = evalCost(item, conversionCost);
                        break;
                    case "BagPricePerTon":
                        preSale.QtyPerTon = conversionCost.Calculate.QtyPerTon;
                        preSale.BagPricePerTon = evalCost(item, conversionCost);
                        break;
                    default:
                        break;
                }
            }

            return preSale;
        }
        public double eval(FormulaCal formula, ProductPriceCalSingleModel priceCalc)
        {
            Expression e = new Expression(formula.detail);
            Type myClassType = priceCalc.Calculate.GetType();
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (var variableItem in formula.variables)
            {
                foreach (PropertyInfo property in properties)
                {
                    double value = (double)property.GetValue(priceCalc.Calculate, null);
                    if (variableItem.ColumnName.Contains(property.Name))
                        e.addArguments(new Argument(variableItem.ColumnName, value));
                }
            }

            double result = 0;
            if (!Double.IsNaN(e.calculate()))
                result = Math.Round(e.calculate(), 2);

            return result;
        }
        public double eval(FormulaCal formula, ProductPriceCalModel priceCalc, ProductRMCost product)
        {
            Expression e = new Expression(formula.detail);
            Type myClassType = product.Calculate.GetType();
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (var variableItem in formula.variables)
            {
                foreach (PropertyInfo property in properties)
                {
                    double value = (double)property.GetValue(product.Calculate, null);
                    if (variableItem.ColumnName.Contains(property.Name))
                        e.addArguments(new Argument(variableItem.ColumnName, value));
                }
            }

            double result = 0;
            if (!Double.IsNaN(e.calculate()))
                result = Math.Round(e.calculate(), 2);

            return result;
        }
        public double evalCost(FormulaCal formula, ConversionCostModel conversionCost)
        {
            Expression e = new Expression(formula.detail);

            Type myClassType = conversionCost.Calculate.GetType();
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (var variableItem in formula.variables)
            {
                foreach (PropertyInfo property in properties)
                {
                    double value = (double)property.GetValue(conversionCost.Calculate, null);
                    if (variableItem.ColumnName.Contains(property.Name))
                        e.addArguments(new Argument(variableItem.ColumnName, value));
                }
            }

            double result = 0;
            if (!Double.IsNaN(e.calculate()))
                result = Math.Round(e.calculate(), 2);

            return result;
        }
        public double evalPaperPrice(FormulaCal formula, CalculatePaperPriceModel calculatePaper)
        {
            Expression e = new Expression(formula.detail);

            Type myClassType = calculatePaper.Calculate.GetType();
            PropertyInfo[] properties = myClassType.GetProperties();
            foreach (var variableItem in formula.variables)
            {
                foreach (PropertyInfo property in properties)
                {
                    double value = (double)property.GetValue(calculatePaper.Calculate, null);
                    if (variableItem.ColumnName.Contains(property.Name))
                        e.addArguments(new Argument(variableItem.ColumnName, value));
                }
            }

            double result = 0;
            if (!Double.IsNaN(e.calculate()))
                result = Math.Round(e.calculate(), 2);

            return result;
        }

    }
}
