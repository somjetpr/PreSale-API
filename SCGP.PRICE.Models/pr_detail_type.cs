using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace SCGP.PRICE.Models
{
    public class pr_detail_type : BaseEntity
    {
        public string name { get; set; }
        public string bu_type { get; set; }
        public virtual ICollection<pr_detail> pr_details { get; set; }
        public pr_detail_type()
        {
            pr_details = new List<pr_detail>();
        }
    }
}
