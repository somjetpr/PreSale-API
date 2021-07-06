using org.mariuszgromada.math.mxparser;
using SCGP.PRICE.Core.BL.Operation.Extension;
using SCGP.PRICE.Core.BL.ShippingArea;
using SCGP.PRICE.Core.Context;
using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace SCGP.PRICE.Core.BL.Operation
{
    public class PreSale : BaseBLL, IPreSale
    {
        private readonly IEfRepository<PriceCalc> priceCalcRepository;
        private readonly IEfRepository<pr_product> productRepository;
        private readonly IEfRepository<pr_product_group> productgroupRepository;
        private readonly IEfRepository<pr_formula_group> formulagroupRepository;
        private readonly IEfRepository<pr_bag_of_type> bagOftypeRepository;
        private readonly IEfRepository<pr_formula> formulaRepository;
        private readonly IEfRepository<pr_record> recordRepository;
        private readonly IEfRepository<pr_record_detail> recorddetailRepository;
        private readonly IEfRepository<pr_production_option_cost> optionCostRepository;
        private readonly IShippingArea shipareaService;
        public PreSale(IEfRepository<PriceCalc> _priceCalcRepository,
                       IEfRepository<pr_product> _productRepository,
                       IEfRepository<pr_product_group> _productgroupRepository,
                       IEfRepository<pr_formula_group> _formulagroupRepository,
                       IEfRepository<pr_formula> _formulaRepository,
                       IEfRepository<pr_bag_of_type> _bagOftypeRepository,
                       IEfRepository<pr_record> _recordRepository,
                       IEfRepository<pr_record_detail> _recorddetailRepository,
                        IEfRepository<pr_production_option_cost> _optionCostRepository,
                       IShippingArea _shipareaService)
        {
            priceCalcRepository = _priceCalcRepository;
            productRepository = _productRepository;
            productgroupRepository = _productgroupRepository;
            formulagroupRepository = _formulagroupRepository;
            formulaRepository = _formulaRepository;
            bagOftypeRepository = _bagOftypeRepository;
            recordRepository = _recordRepository;
            recorddetailRepository = _recorddetailRepository;
            optionCostRepository = _optionCostRepository;
            shipareaService = _shipareaService;

        }

        public async Task<PricingSingleModel> PricingCalculate(ProductPriceCalSingleModel priceCalc)
        {
            try
            {
                PriceCalculator calculator = new PriceCalculator();

                var productQuery = productRepository.Table.Where(x => x.isActive)
                            .Include(x => x.pr_product_group).AsQueryable();

                if (!string.IsNullOrWhiteSpace(priceCalc.Vender))
                    productQuery = productQuery.Where(x => x.vender_Id == priceCalc.Vender).AsQueryable();
                if (!string.IsNullOrWhiteSpace(priceCalc.product_group_name))
                    productQuery = productQuery.Where(x => x.pr_product_group.name == priceCalc.product_group_name).AsQueryable();
                if (!string.IsNullOrWhiteSpace(priceCalc.product_name))
                    productQuery = productQuery.Where(x => x.product_name == priceCalc.product_name).AsQueryable();
                if (priceCalc.product_group_name == "P/E บาทต่อ ตรม." && priceCalc.Calculate.PEThickness != 0)
                    productQuery = productQuery.Where(x => x.gram == priceCalc.Calculate.PEThickness.ToString()).AsQueryable();
                if (!productQuery.Any())
                    throw new Exception("Not found Product");

                var maspro = productQuery.FirstOrDefault();
                priceCalc.Calculate.Gram = Utils.ConvertToDouble(maspro.gram);
                priceCalc.Calculate.LP = Convert.ToDouble(maspro.list_price_new);
                priceCalc.Calculate.RMCost = Convert.ToDouble(maspro.cost);

                var formulaQuery = formulaRepository.Table
                                  .Where(x => x.isActive)
                                  .Include(x => x.bagOftype)
                                  .Include(x => x.formulagroup)
                                  .Include(x => x.formula_variables).AsQueryable();

                if (!string.IsNullOrWhiteSpace(priceCalc.Vender))
                    formulaQuery = formulaQuery.Where(x => x.bagOftype.group == priceCalc.Vender).AsQueryable();

                if (!string.IsNullOrWhiteSpace(priceCalc.product_group_name))
                    formulaQuery = formulaQuery.Where(x => x.name == priceCalc.product_group_name || x.name == "Paper Price").AsQueryable();

                var fls = formulaQuery.Select(s => new FormulaCal
                {
                    formula_group_name = s.formulagroup.name,
                    formula_name = s.name,
                    detail = s.detail,
                    variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
                }).ToList();

                priceCalc.formulas = fls;

                var preSale = calculator.PreSaleEvaluate(priceCalc);

                var shipAreaCalc = new BagPriceCalculate();
                if (priceCalc.conversion != null)
                {
                    if (priceCalc.conversion.Calculate.TotalProductionCost > 0)
                    {
                        shipAreaCalc = await shipareaService.GetShipAreaCalculate(priceCalc.conversion);
                        preSale.bagPriceCalculate = shipAreaCalc;
                    }
                }

                return preSale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PricingModel> PricingCalculate(ProductPriceCalModel priceCalc)
        {
            try
            {
                PriceCalculator calculator = new PriceCalculator();

                #region TOTAL PAPER PRICE EAVLUATE
                var paperprice = new PaperPriceCalculate();
                if (priceCalc.calculatePaper != null)
                {
                    if (priceCalc.calculatePaper.Calculate.TotalProductionCost > 0 && priceCalc.calculatePaper.Calculate.TotalPaperRoll > 0 && priceCalc.calculatePaper.Calculate.TotalRMCost > 0)
                    {
                        var formulaQuery = formulaRepository.Table
                          .Where(x => x.isActive)
                          .Include(x => x.bagOftype)
                          .Include(x => x.formulagroup)
                          .Include(x => x.formula_variables).AsQueryable();

                        if (!string.IsNullOrWhiteSpace(priceCalc.Vender))
                            formulaQuery = formulaQuery.Where(x => x.bagOftype.group == priceCalc.Vender && x.name == "Paper Price").AsQueryable();

                        var fls = formulaQuery.Select(s => new FormulaCal
                        {
                            formula_group_name = s.formulagroup.name,
                            formula_name = s.name,
                            detail = s.detail,
                            seq = s.formulagroup.seq,
                            variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
                        }).ToList();

                        priceCalc.calculatePaper.formulas = fls.OrderBy(s => s.seq).ToList();
                        paperprice = calculator.PaperPriceEvaluate(priceCalc.calculatePaper);
                    }
                }
                #endregion

                #region GET PRODUCT AND FORMULA
                double wastetemp = 0;
                foreach (var item in priceCalc.Products)
                {
                    if (!string.IsNullOrWhiteSpace(item.product_name))
                    {
                        var productQuery = productRepository.Table.Where(x => x.isActive)
                             .Include(x => x.pr_product_group).AsQueryable();

                        if (!string.IsNullOrWhiteSpace(priceCalc.Vender))
                            productQuery = productQuery.Where(x => x.vender_Id == priceCalc.Vender).AsQueryable();
                        if (!string.IsNullOrWhiteSpace(item.product_group_name))
                            productQuery = productQuery.Where(x => x.pr_product_group.name == item.product_group_name).AsQueryable();
                        if (!string.IsNullOrWhiteSpace(item.product_name))
                            productQuery = productQuery.Where(x => x.product_name == item.product_name).AsQueryable();
                        if (item.product_group_name == "P/E บาทต่อ ตรม." && item.Calculate.PEThickness != 0)
                            productQuery = productQuery.Where(x => x.gram == item.Calculate.PEThickness.ToString()).AsQueryable();
                        if (!productQuery.Any())
                            throw new Exception("Not found Product");

                        var maspro = productQuery.FirstOrDefault();
                        item.Calculate.Gram = Convert.ToDouble(maspro.gram);
                        item.Calculate.LP = Convert.ToDouble(maspro.list_price_new);
                        item.Calculate.RMCost = Convert.ToDouble(maspro.cost);
                        item.Calculate.TotalPaperSellingPrice = paperprice.TotalPaperSellingPrice;

                        wastetemp = item.Calculate.Waste;

                        var formulaQuery = formulaRepository.Table
                                      .Where(x => x.isActive)
                                      .Include(x => x.bagOftype)
                                      .Include(x => x.formulagroup)
                                      .Include(x => x.formula_variables).AsQueryable();

                        if (!string.IsNullOrWhiteSpace(priceCalc.Vender))
                            formulaQuery = formulaQuery.Where(x => x.bagOftype.group == priceCalc.Vender).AsQueryable();

                        if (!string.IsNullOrWhiteSpace(item.product_group_name))
                            formulaQuery = formulaQuery.Where(x => x.name == item.product_group_name || x.name == "Paper Price").AsQueryable();

                        var fls = formulaQuery.Select(s => new FormulaCal
                        {
                            formula_group_name = s.formulagroup.name,
                            formula_name = s.name,
                            detail = s.detail,
                            seq = s.formulagroup.seq,
                            variables = s.formula_variables.Select(s => new VariableCal { Id = s.Id, ColumnName = s.variable_name }).ToList()
                        }).ToList();

                        item.formulas = fls.OrderBy(s => s.seq).ToList();
                    }
                }
                #endregion

                #region RM COST EAVLUATE
                var preSaleRMCost = calculator.PreSaleEvaluate(priceCalc);

                double TotalListPricePaperRoll = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Paper Roll").Sum(s => s.ListPrice);
                double TotalListPricePaperValve = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Paper Valve").Sum(s => s.ListPrice);
                double TotalListPricePaperTape = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Paper Tape").Sum(s => s.ListPrice);
                double TotalListPriceSubTape = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Sub Tape").Sum(s => s.ListPrice);
                double TotalListPriceSleeve = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Sleeve").Sum(s => s.ListPrice);
                double TotalListPriceMaskTape = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "เทปปะปาก").Sum(s => s.ListPrice);
                double TotalListPricePE = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "P/E บาทต่อ ตรม.").Sum(s => s.ListPrice);
                double TotalListPriceLaminate = preSaleRMCost.rMCostCalculates.Where(x => x.product_group_name == "Laminate").Sum(s => s.ListPrice);

                foreach (var item in priceCalc.Products)
                {
                    if (item.product_group_name == "Paper Roll")
                        item.Calculate.TotalListPrice = TotalListPricePaperRoll;
                    if (item.product_group_name == "Paper Valve")
                        item.Calculate.TotalListPrice = TotalListPricePaperValve;
                    if (item.product_group_name == "Paper Tape")
                        item.Calculate.TotalListPrice = TotalListPricePaperTape;
                    if (item.product_group_name == "Sub Tape")
                        item.Calculate.TotalListPrice = TotalListPriceSubTape;
                    if (item.product_group_name == "Sleeve")
                        item.Calculate.TotalListPrice = TotalListPriceSleeve;
                    if (item.product_group_name == "เทปปะปาก")
                        item.Calculate.TotalListPrice = TotalListPriceMaskTape;
                    if (item.product_group_name == "P/E บาทต่อ ตรม.")
                        item.Calculate.TotalListPrice = TotalListPricePE;
                    if (item.product_group_name == "Laminate")
                        item.Calculate.TotalListPrice = TotalListPriceLaminate;
                    item.Calculate.Waste = wastetemp;
                }
                #endregion

                #region PAPER PRICE EAVLUATE BY PRODUCT
                var preSalePaperPrice = calculator.PreSalePaperEvaluate(priceCalc);
                preSalePaperPrice.PaperPriceCalculate = paperprice;
                #endregion

                #region CONVERSION COST AND BAG PRICING EAVLUATE
                var shipAreaCalc = new BagPriceCalculate();
                if (priceCalc.conversion.Calculate.TotalProductionCost > 0)
                {
                    shipAreaCalc = await shipareaService.GetShipAreaCalculate(priceCalc.conversion);
                    preSalePaperPrice.bagPriceCalculate = shipAreaCalc;
                }
                #endregion

                return preSalePaperPrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BagPriceCalculate> ConversionCost(ConversionCostModel costPriceCal)
        {
            try
            {
                PriceCalculator calculator = new PriceCalculator();

                var preSale = calculator.ConverCost(costPriceCal);

                return preSale;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PreSaleView> Add(PreSaleView PS)
        {
            var vender = await bagOftypeRepository.Table.Where(x => x.group == PS.Vender.ToString()).FirstOrDefaultAsync();
            if (vender == null)
                throw new Exception("ไม่พบข้อมูลผู้ขาย");
            var bagOftype = await bagOftypeRepository.Table.Where(x => x.Id == PS.TypeOfBag).FirstOrDefaultAsync();
            if (bagOftype == null)
                throw new Exception("ไม่พบข้อมูลประเภทถุง");

            var ps = new pr_record
            {
                customer_vendor = PS.Vender,
                customer_bag_type = PS.TypeOfBag,
                customer_name = PS.CustomerName,
                customer_sold_to = PS.SoldTo,
                customer_dealer = PS.Sale,
                customer_bag_combination = PS.BagsCombination,
                //########## Product Detail ##########//
                product_material_id = PS.MaterialID,
                product_description = PS.MaterialDescription,
                product_name = PS.ProductName,
                product_domestic = PS.SaleCode,
                product_dealer = PS.Industry,
                product_layer_amount = PS.BagLayer,
                product_hierarchy = PS.ProHierarchy,
                product_unit_used = PS.UnitUsedMonth,
                product_color = PS.Color,
                product_bag_type = PS.BagType,
                product_waste = PS.Waste,
                product_bottom_way = PS.BottomDirection,
                product_valve_type = PS.ValveType,
                product_valve_onside = PS.ValveSide,
                product_vale_depth = PS.ValveDept,
                product_valve_length = PS.ValveLength,
                product_valve_width = PS.ValveWidth,
                //########## Total RM Cost ##########//
                total_tube = PS.TotTube,
                total_waste = PS.TotWaste,
                other_value_1 = PS.TotNetWeight,
                other_value_2 = PS.TotLP,
                other_value_3 = PS.TotListPrice,
                other_value_4 = PS.TotRMCostBathTon,
                other_value_5 = PS.TotRMCost,
                other_value_6 = PS.GrandTotRMCost,
                //########## Bag Size/PE Specification ##########//
                bag_width = PS.Width,
                bag_length = PS.Length,
                bag_bottom = PS.Bottom,
                bag_adjust_page = PS.AdjustPage,
                bag_page = PS.PaperPage,
                bag_gear = PS.Gear,
                bag_patch_tape_width = PS.PatchTapeWidth,
                bag_patch_tape_length = PS.PatchTapeLength,
                bag_handle = PS.BagEar,
                bag_pe__width = PS.Width,
                bag_pe_length = PS.Length,
                bag_pe_laminate = PS.PELaminate,
                bag_pe_thickness = PS.PEThickness,
                bag_lamination = PS.Lamination,
                bag_plastic_type = PS.PEType,
                //########## Shipping Detail ##########//
                shipping_packing = PS.Packing,
                shipping_bag_per_pack = PS.PackQty,
                shipping_bag_per_pallet = PS.PalletQty,
                shipping_pallet_per_car = PS.PalletUnit,
                shipping_amount_per_order = PS.ForwardingTripQty,
                shipping_bag_compress = PS.BagCompressionId,
                shipping_slot = PS.Perforate,
                shipping_mark = PS.ShipingMark,
                shipping_pack_binding = PS.Bundling,
                shipping_pallet_pattern = PS.BagPatternPallet,
                shipping_specail_spec = PS.SpecialSpec,
                //########## Bag Pricing ##########//
                print_per_production_id = PS.BagProductCost,
                shipping_area_id = PS.Shiping,
                vc_id = PS.VCId,
                fc_id = PS.FCId,
                plastic_value = PS.PlasticCost,
                plastic_type = PS.PlasticType,
                laminate_value = PS.LaminateCostAmt,
                shipping_amount = PS.ShipingAmt,
                other_cost = PS.OtherCostAmt,
                total_production_cost = PS.TotConversion,
                other_value_7 = PS.CostPer1000LP,
                other_value_8 = PS.Increase,
                other_value_9 = PS.CostPer1000SP,
                other_value_10 = PS.IncreaseLP,
                other_value_11 = PS.IncreaseSP,
                other_value_12 = PS.ProfitLossLP,
                other_value_13 = PS.ProfitLossSP,
                other_value_14 = PS.GrossProfitPer1000LP,
                other_value_15 = PS.GrossProfitPer1000SP,
                other_value_16 = PS.GrandTotRMCost,
                other_value_17 = PS.BagPriceBahtTon,
                other_value_18 = PS.TotPPAllocation,
                other_value_19 = PS.TotPPSellPriceBT,
                other_value_20 = PS.TotPPSellPrice1000PC,
            };

            List<pr_record_conversion> optionCostsItems = new List<pr_record_conversion>();
            foreach (var item in PS.OptionCosts)
            {
                var optioncost = optionCostRepository.Table.Where(x => x.Id == item.ConversionId).FirstOrDefault();
                var psitem = new pr_record_conversion
                {
                    optionCost = optioncost,
                    value = item.value
                };

                optionCostsItems.Add(psitem);
            }

            ps.Conversions = optionCostsItems;

            List<pr_record_detail> recordItems = new List<pr_record_detail>();
            foreach (var item in PS.Items)
            {
                var psitem = new pr_record_detail
                {
                    type_id = item.GroupId,
                    layer = item.Layer,
                    grade = item.Grade,
                    gram = item.Gram,
                    tube = item.Tube,
                    waste = item.Waste,
                    other_value_1 = item.NetWeight,
                    other_value_2 = item.ListPriceBT,
                    other_value_3 = item.ListPriceB1000PC,
                    other_value_4 = item.RMCostBT,
                    other_value_5 = item.RMCostB1000PC,
                    allocation_percent = item.Allocation,
                    other_value_6 = item.SellPriceBT,
                    other_value_7 = item.SellPrice1000PC
                };

                recordItems.Add(psitem);
            }

            ps.RecordItems = recordItems;

            await recordRepository.AddAsync(ps);

            return await Get(ps.Id);
        }
        public async Task<PreSaleView> Update(PreSaleView PS)
        {
            var ps = recordRepository.Table.Where(x => x.Id == PS.RecordId)
                               .Include(x => x.RecordItems)
                               .Include(x => x.Conversions).FirstOrDefault();

            var vender = await bagOftypeRepository.Table.Where(x => x.group == PS.Vender.ToString()).FirstOrDefaultAsync();
            if (vender == null)
                throw new Exception("ไม่พบข้อมูลผู้ขาย");
            var bagOftype = await bagOftypeRepository.Table.Where(x => x.Id == PS.TypeOfBag).FirstOrDefaultAsync();
            if (bagOftype == null)
                throw new Exception("ไม่พบข้อมูลประเภทถุง");
            if (ps.record_state == record_state.Approved || ps.record_state == record_state.Completed)
                throw new Exception("ไม่สามารถแก้ไขรายการได้");

            ps.customer_vendor = PS.Vender;
            ps.customer_bag_type = PS.TypeOfBag;
            ps.customer_name = PS.CustomerName;
            ps.customer_sold_to = PS.SoldTo;
            ps.customer_dealer = PS.Sale;
            ps.customer_bag_combination = PS.BagsCombination;
            //########## Product Detail ##########//
            ps.product_material_id = PS.MaterialID;
            ps.product_description = PS.MaterialDescription;
            ps.product_name = PS.ProductName;
            ps.product_domestic = PS.SaleCode;
            ps.product_dealer = PS.Industry;
            ps.product_layer_amount = PS.BagLayer;
            ps.product_hierarchy = PS.ProHierarchy;
            ps.product_unit_used = PS.UnitUsedMonth;
            ps.product_color = PS.Color;
            ps.product_bag_type = PS.BagType;
            ps.product_waste = PS.Waste;
            ps.product_bottom_way = PS.BottomDirection;
            ps.product_valve_type = PS.ValveType;
            ps.product_valve_onside = PS.ValveSide;
            ps.product_vale_depth = PS.ValveDept;
            ps.product_valve_length = PS.ValveLength;
            ps.product_valve_width = PS.ValveWidth;
            //########## Total RM Cost ##########//
            ps.total_tube = PS.TotTube;
            ps.total_waste = PS.TotWaste;
            ps.other_value_1 = PS.TotNetWeight;
            ps.other_value_2 = PS.TotLP;
            ps.other_value_3 = PS.TotListPrice;
            ps.other_value_4 = PS.TotRMCostBathTon;
            ps.other_value_5 = PS.TotRMCost;
            ps.other_value_6 = PS.GrandTotRMCost;
            //########## Bag Size/PE Specification ##########//
            ps.bag_width = PS.Width;
            ps.bag_length = PS.Length;
            ps.bag_bottom = PS.Bottom;
            ps.bag_adjust_page = PS.AdjustPage;
            ps.bag_page = PS.PaperPage;
            ps.bag_gear = PS.Gear;
            ps.bag_patch_tape_width = PS.PatchTapeWidth;
            ps.bag_patch_tape_length = PS.PatchTapeLength;
            ps.bag_handle = PS.BagEar;
            ps.bag_pe__width = PS.Width;
            ps.bag_pe_length = PS.Length;
            ps.bag_pe_laminate = PS.PELaminate;
            ps.bag_pe_thickness = PS.PEThickness;
            ps.bag_lamination = PS.Lamination;
            ps.bag_plastic_type = PS.PEType;
            //########## Shipping Detail ##########//
            ps.shipping_packing = PS.Packing;
            ps.shipping_bag_per_pack = PS.PackQty;
            ps.shipping_bag_per_pallet = PS.PalletQty;
            ps.shipping_pallet_per_car = PS.PalletUnit;
            ps.shipping_amount_per_order = PS.ForwardingTripQty;
            ps.shipping_bag_compress = PS.BagCompressionId;
            ps.shipping_slot = PS.Perforate;
            ps.shipping_mark = PS.ShipingMark;
            ps.shipping_pack_binding = PS.Bundling;
            ps.shipping_pallet_pattern = PS.BagPatternPallet;
            ps.shipping_specail_spec = PS.SpecialSpec;
            //########## Bag Pricing ##########//
            ps.print_per_production_id = PS.BagProductCost;
            ps.shipping_area_id = PS.Shiping;
            ps.vc_id = PS.VCId;
            ps.fc_id = PS.FCId;
            ps.plastic_value = PS.PlasticCost;
            ps.plastic_type = PS.PlasticType;
            ps.laminate_value = PS.LaminateCostAmt;
            ps.shipping_amount = PS.ShipingAmt;
            ps.other_cost = PS.OtherCostAmt;
            ps.total_production_cost = PS.TotConversion;
            ps.other_value_7 = PS.CostPer1000LP;
            ps.other_value_8 = PS.Increase;
            ps.other_value_9 = PS.CostPer1000SP;
            ps.other_value_10 = PS.IncreaseLP;
            ps.other_value_11 = PS.IncreaseSP;
            ps.other_value_12 = PS.ProfitLossLP;
            ps.other_value_13 = PS.ProfitLossSP;
            ps.other_value_14 = PS.GrossProfitPer1000LP;
            ps.other_value_15 = PS.GrossProfitPer1000SP;
            ps.other_value_16 = PS.GrandTotRMCost;
            ps.other_value_17 = PS.BagPriceBahtTon;
            ps.other_value_18 = PS.TotPPAllocation;
            ps.other_value_19 = PS.TotPPSellPriceBT;
            ps.other_value_20 = PS.TotPPSellPrice1000PC;

            var items = ps.RecordItems.Where(x => x.isActive).ToList();
            foreach (var item in items)
            {
                var has = PS.Items.Any(x => x.RecordDetailId == item.Id);
                if (!has)
                {
                    item.isActive = false;
                    item.updated_date = DateTime.Now;
                    item.updated_by = UserName;
                }
                else
                {
                    var i = PS.Items.FirstOrDefault(x => x.RecordDetailId == item.Id);
                    item.type_id = i.GroupId;
                    item.layer = i.Layer;
                    item.grade = i.Grade;
                    item.gram = i.Gram;
                    item.tube = i.Tube;
                    item.waste = i.Waste;
                    item.other_value_1 = i.NetWeight;
                    item.other_value_2 = i.ListPriceBT;
                    item.other_value_3 = i.ListPriceB1000PC;
                    item.other_value_4 = i.RMCostBT;
                    item.other_value_5 = i.RMCostB1000PC;
                    item.allocation_percent = i.Allocation;
                    item.other_value_6 = i.SellPriceBT;
                    item.other_value_7 = i.SellPrice1000PC;
                }
            }

            foreach (var item in PS.Items.ToList())
            {
                if (item.RecordDetailId == 0)
                {
                    var _item = new pr_record_detail
                    {
                        type_id = item.GroupId,
                        layer = item.Layer,
                        grade = item.Grade,
                        gram = item.Gram,
                        tube = item.Tube,
                        waste = item.Waste,
                        other_value_1 = item.NetWeight,
                        other_value_2 = item.ListPriceBT,
                        other_value_3 = item.ListPriceB1000PC,
                        other_value_4 = item.RMCostBT,
                        other_value_5 = item.RMCostB1000PC,
                        allocation_percent = item.Allocation,
                        other_value_6 = item.SellPriceBT,
                        other_value_7 = item.SellPrice1000PC
                    };
                    ps.RecordItems.Add(_item);
                }
            }

            var optionCostItems = ps.Conversions.Where(x => x.isActive).ToList();
            foreach (var item in optionCostItems)
            {
                var optioncost = optionCostRepository.Table.Where(x => x.Id == item.Id).FirstOrDefault();
                var has = PS.OptionCosts.Any(x => x.ConversionId == item.Id);
                if (!has)
                {
                    item.isActive = false;
                    item.updated_date = DateTime.Now;
                    item.updated_by = UserName;
                }
                else
                {
                    var i = PS.OptionCosts.FirstOrDefault(x => x.ConversionId == item.Id);
                    item.optionCost = optioncost;
                    item.value = i.value;
                }
            }

            foreach (var item in PS.OptionCosts.ToList())
            {
                if (item.ConversionId == 0)
                {
                    var _item = new pr_record_conversion
                    {
                        //id = item.RecordId,
                        value = item.value,
                        created_date = DateTime.Now,
                        created_by = UserName,
                        updated_date = DateTime.Now,
                        updated_by = UserName,
                    };
                    ps.Conversions.Add(_item);
                }
            }

            if (PS.Items.Count > 0)
                ps.record_state = record_state.New;

            await recordRepository.UpdateAsync(ps);

            return await Get(ps.Id);
        }
        public async Task<PreSaleView> Get(int recordId)
        {
            var record = recordRepository.Table.Where(x => x.Id == recordId);
            if (!record.Any())
                throw new Exception("ไม่มพบรายการขาย");

            return record.ToSingleViewModel();
        }
    }
}
