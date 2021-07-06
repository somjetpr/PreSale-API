using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_product_log : BaseEntity
    {
        public string productr_id { get; set; }
        public string detail { get; set; }
        public string value { get; set; }
    }
}
