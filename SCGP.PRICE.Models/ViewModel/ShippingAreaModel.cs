using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class ShippingAreaModel
    {
        public int Id { get; set; }
        public string area_name { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal area_price { get; set; }
        public string vender_Id { get; set; }
    }
}
