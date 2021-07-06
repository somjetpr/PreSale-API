using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_record_detail : BaseEntity
    {
        public int layer { get; set; }
        public int grade { get; set; }
        public double gram { get; set; }
        public double tube { get; set; }
        public double waste { get; set; }
        public double other_value_1 { get; set; }
        public double other_value_2 { get; set; }
        public double other_value_3 { get; set; }
        public double other_value_4 { get; set; }
        public double other_value_5 { get; set; }
        public double allocation_percent { get; set; }
        public double other_value_6 { get; set; }
        public double other_value_7 { get; set; }
        public int type_id { get; set; }
        public int sub_type_id { get; set; }
        [ForeignKey("record_id")]
        public virtual pr_record Record { get; set; }

    }
}
