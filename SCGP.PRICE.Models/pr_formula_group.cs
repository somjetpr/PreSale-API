using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace SCGP.PRICE.Models
{
    public class pr_formula_group : BaseEntity
    {
        public string name { get; set; }
        public int seq { get; set; }
        public virtual ICollection<pr_formula> formulas { get; set; }
        public pr_formula_group()
        {
            formulas = new List<pr_formula>();
        }
    }
}
