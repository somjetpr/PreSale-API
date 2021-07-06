using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_product_group : BaseEntity
    {
        public string name { get; set; }

        public virtual ICollection<pr_product> products { get; set; }
        public pr_product_group()
        {
            products = new List<pr_product>();
        }
    }
}
