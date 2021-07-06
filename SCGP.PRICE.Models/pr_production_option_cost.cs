using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_production_option_cost : BaseEntity
    {
        public string name { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal sale_price { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal cost_price { get; set; }
        public string vender_Id { get; set; }
        public virtual pr_formula formula { get; set; }
    }

}
