using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{

    public class pr_bag_of_type : BaseEntity
    {
        public string name { get; set; }
        public string group { get; set; }
        public string type { get; set; }

        public virtual ICollection<pr_formula> formulas { get; set; }
        public virtual ICollection<pr_production_cost> Costs { get; set; }
        public pr_bag_of_type()
        {
            formulas = new List<pr_formula>();
            Costs = new List<pr_production_cost>();
        }
    }
}
