using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
   public class pr_detail : BaseEntity
    {
        public string name { get; set; }
        public string code { get; set; }
        public int value { get; set; }
        public virtual pr_detail_type pr_detail_type { get; set; }
    }
}
