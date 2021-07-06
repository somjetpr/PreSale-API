using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
   public class BagModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int value { get; set; }
        public int detail_type_id { get; set; }
        public string typename { get; set; }
    }
}
