using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_sale : BaseEntity
    { 
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int status { get; set; }
    }
}
