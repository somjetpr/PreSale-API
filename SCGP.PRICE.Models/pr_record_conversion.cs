using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_record_conversion : BaseEntity
    {
        public double value { get; set; }
        [ForeignKey("record_id")]
        public virtual pr_record records { get; set; }
        [ForeignKey("conversion_id")]
        public virtual pr_production_option_cost optionCost { get; set; }
    }
}
