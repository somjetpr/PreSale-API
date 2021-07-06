using Microsoft.EntityFrameworkCore;
using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCGP.PRICE.Core.BL.Operation
{
    public static class PreSaleExtention
    {
        public static PreSaleView ToSingleViewModel(this IQueryable<pr_record> records)
        {
            PreSaleView psview = records.Select(PS => new PreSaleView
            {
                Vender = PS.customer_vendor,
                TypeOfBag = PS.customer_bag_type,
                CustomerName = PS.customer_name,
                SoldTo = PS.customer_sold_to,
                Sale = PS.customer_dealer,
                BagsCombination = PS.customer_bag_combination,
                //########## Product Detail ##########//
                MaterialID = PS.product_material_id,
                MaterialDescription = PS.product_description,
                ProductName = PS.product_name,
                SaleCode = PS.product_domestic,
                Industry = PS.product_dealer,
                BagLayer = PS.product_layer_amount,
                ProHierarchy = PS.product_hierarchy,
                UnitUsedMonth = PS.product_unit_used,
                Color = PS.product_color,
                BagType = PS.product_bag_type,
                Waste = PS.product_waste,
                BottomDirection = PS.product_bottom_way,
                ValveType = PS.product_valve_type,
                ValveSide = PS.product_valve_onside,
                ValveDept = PS.product_vale_depth,
                ValveLength = PS.product_valve_length,
                ValveWidth = PS.product_valve_width,
                //########## Total RM Cost ##########//
                TotTube = PS.total_tube,
                TotWaste = PS.total_waste,
                TotNetWeight = PS.other_value_1,
                TotLP = PS.other_value_2,
                TotListPrice = PS.other_value_3,
                TotRMCostBathTon = PS.other_value_4,
                TotRMCost = PS.other_value_5,
                GrandTotRMCost = PS.other_value_6,
                //########## Bag Size/PE Specification ##########//
                Width = PS.bag_width,
                Length = PS.bag_length,
                Bottom = PS.bag_bottom,
                AdjustPage = PS.bag_adjust_page,
                PaperPage = PS.bag_page,
                Gear = PS.bag_gear,
                PatchTapeWidth = PS.bag_patch_tape_width,
                PatchTapeLength = PS.bag_patch_tape_length,
                BagEar = PS.bag_handle,
                PEWidth = PS.bag_pe__width,
                PELength = PS.bag_pe_length,
                PELaminate = PS.bag_pe_laminate,
                PEThickness = PS.bag_pe_thickness,
                Lamination = PS.bag_lamination,
                PlasticType = PS.bag_plastic_type,
                //########## Shipping Detail ##########//
                Packing = PS.shipping_packing,
                PackQty = PS.shipping_bag_per_pack,
                PalletQty = PS.shipping_bag_per_pallet,
                PalletUnit = PS.shipping_pallet_per_car,
                ForwardingTripQty = PS.shipping_amount_per_order,
                BagCompressionId = PS.shipping_bag_compress,
                Perforate = PS.shipping_slot,
                ShipingMark = PS.shipping_mark,
                Bundling = PS.shipping_pack_binding,
                SpecialSpec = PS.shipping_specail_spec,
                //########## Bag Pricing ##########//
                BagProductCost = PS.print_per_production_id,
                Shiping = PS.shipping_area_id,
                VCId = PS.vc_id,
                FCId = PS.fc_id,
                PlasticCost = PS.plastic_value,
                LaminateCostAmt = PS.laminate_value,
                ShipingAmt = PS.shipping_amount,
                OtherCostAmt = PS.other_cost,
                TotConversion = PS.total_production_cost,
                CostPer1000LP = PS.other_value_7,
                CostPer1000SP = PS.other_value_8,
                IncreaseLP = PS.other_value_9,
                IncreaseSP = PS.other_value_10,
                IncreaseSellingPrice = PS.other_value_11,
                ProfitLossLP = PS.other_value_12,
                ProfitLossSP = PS.other_value_13,
                GrossProfitPer1000LP = PS.other_value_14,
                GrossProfitPer1000SP = PS.other_value_15,
                //GrandTotRMCost = PS.other_value_16,
                BagPriceBahtTon = PS.other_value_17,
                TotPPAllocation = PS.other_value_18,
                TotPPSellPriceBT = PS.other_value_19,
                TotPPSellPrice1000PC = PS.other_value_20,
            }).FirstOrDefault();

            var items = records.Include(x => x.RecordItems).Select(s => s.RecordItems.ToList()).FirstOrDefault();
            foreach (var item in items.Where(x => x.isActive).ToList())
            {
                var p = new RMCostItem
                {
                    RecordDetailId = item.Id,
                    GroupId = item.type_id,
                    Layer = item.layer,
                    Grade = item.grade,
                    Gram = item.gram,
                    Tube = item.tube,
                    Waste = item.waste,
                    NetWeight = item.other_value_1,
                    ListPriceBT = item.other_value_2,
                    ListPriceB1000PC = item.other_value_3,
                    RMCostBT = item.other_value_4,
                    RMCostB1000PC = item.other_value_5,
                    Allocation = item.allocation_percent,
                    SellPriceBT = item.other_value_6,
                    SellPrice1000PC = item.other_value_7,
                };
                psview.Items.Add(p);
            }

            var convers = records
                .Include(x => x.Conversions)
                .Select(s => s.Conversions.ToList()).FirstOrDefault();

            foreach (var item in convers.Where(x => x.isActive).ToList())
            {
                var p = new ProductionOptionCost
                {
                    ConversionId = item.Id,
                    RecordId = item.records.Id,
                    ProdOptionCostId = item.optionCost == null ? 0 : item.optionCost.Id,
                    ProdOptionCostName = item.optionCost?.name,
                    value = item.value
                };

                psview.OptionCosts.Add(p);
            }

            return psview;
        }
    }
}
