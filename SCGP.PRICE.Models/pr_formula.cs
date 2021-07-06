using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_formula : BaseEntity
    {
        public string name { get; set; }
        public string type_code { get; set; }
        public string formula_code { get; set; }
        public int formula_group { get; set; }
        public string detail { get; set; }
        public virtual pr_formula_group formulagroup { get; set; }
        public virtual pr_bag_of_type bagOftype { get; set; }
        public virtual ICollection<pr_formula_variable> formula_variables { get; set; }
        public pr_formula()
        {
            formula_variables = new List<pr_formula_variable>();
        }
    }
}
