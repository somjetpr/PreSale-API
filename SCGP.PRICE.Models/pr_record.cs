using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_record : BaseEntity
    {
        public int customer_vendor { get; set; }
        public int customer_bag_type { get; set; }
        public string customer_name { get; set; }
        public string customer_sold_to { get; set; }
        public int customer_dealer { get; set; }
        public string customer_bag_combination { get; set; }
        public string product_material_id { get; set; }
        public string product_description { get; set; }
        public string product_name { get; set; }
        public int product_domestic { get; set; }
        public int product_dealer { get; set; }
        public int product_layer_amount { get; set; }
        public string product_hierarchy { get; set; }
        public string product_unit_used { get; set; }
        public string product_color { get; set; }
        public int product_bag_type { get; set; }
        public int product_waste { get; set; }
        public int product_bottom_way { get; set; }
        public int product_valve_type { get; set; }
        public int product_valve_onside { get; set; }
        public double product_vale_depth { get; set; }
        public double product_valve_width { get; set; }
        public double product_valve_length { get; set; }
        public double bag_width { get; set; }
        public double bag_length { get; set; }
        public double bag_bottom { get; set; }
        public double bag_adjust_page { get; set; }
        public double bag_page { get; set; }
        public double bag_gear { get; set; }
        public double bag_patch_tape_width { get; set; }
        public double bag_patch_tape_length { get; set; }
        public int bag_handle { get; set; }
        public double bag_pe__width { get; set; }
        public double bag_pe_length { get; set; }
        public int bag_pe_laminate { get; set; }
        public int bag_pe_thickness { get; set; }
        public int bag_lamination { get; set; }
        public int bag_plastic_type { get; set; }
        public string shipping_packing { get; set; }
        public double shipping_bag_per_pack { get; set; }
        public double shipping_bag_per_pallet { get; set; }
        public double shipping_pallet_per_car { get; set; }
        public double shipping_amount_per_order { get; set; }
        public int shipping_bag_compress { get; set; }
        public int shipping_slot { get; set; }
        public int shipping_mark { get; set; }
        public int shipping_pack_binding { get; set; }
        public int shipping_pallet_pattern { get; set; }
        public string shipping_specail_spec { get; set; }
        public double total_tube { get; set; }
        public double total_waste { get; set; }
        public double other_value_1 { get; set; }
        public double other_value_2 { get; set; }
        public double other_value_3 { get; set; }
        public double other_value_4 { get; set; }
        public double other_value_5 { get; set; }
        public double other_value_6 { get; set; }
        public double other_value_7 { get; set; }
        public double other_value_8 { get; set; }
        public double other_value_9 { get; set; }
        public double other_value_10 { get; set; }
        public double other_value_11 { get; set; }
        public double other_value_12 { get; set; }
        public double other_value_13 { get; set; }
        public double other_value_14 { get; set; }
        public double other_value_15 { get; set; }
        public double other_value_16 { get; set; }
        public double other_value_17 { get; set; }
        public double other_value_18 { get; set; }
        public double other_value_19 { get; set; }
        public double other_value_20 { get; set; }
        public int print_per_production_id { get; set; }
        public int vc_id { get; set; }
        public int fc_id { get; set; }
        public int plastic_value { get; set; }
        public int plastic_type { get; set; }
        public int laminate_value { get; set; }
        public int shipping_area_id { get; set; }
        public double shipping_amount { get; set; }
        public double other_cost { get; set; }
        public double total_production_cost { get; set; }
        public record_state record_state { get; set; }
        public virtual ICollection<pr_record_detail> RecordItems { get; set; }
        public virtual ICollection<pr_record_conversion> Conversions { get; set; }
        public pr_record()
        {
            RecordItems = new List<pr_record_detail>();
        }
    }

    public enum record_state
    {
        Unfinished,
        New,
        Pending,
        Approved,
        Completed
    }
}
