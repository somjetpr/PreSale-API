using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_product : BaseEntity
    {
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string gram { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal list_price_old { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal list_price_new { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal cost { get; set; }
        public string type { get; set; }
        public string vender_Id { get; set; }
        public virtual pr_product_group pr_product_group { get; set; }
    }
}
