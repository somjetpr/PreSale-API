using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_production_cost :BaseEntity
    {
        public string name { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal price { get; set; }
        public virtual pr_bag_of_type bagOftype { get; set; }
        public virtual pr_formula formula { get; set; }
    }
}
