using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_formula_variable : BaseEntity
    {
        public string variable_name { get; set; }

        public virtual pr_formula formula { get; set; }
    }
}
