using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_user : BaseEntity
    {
        public string username { get; set; }
        public string name { get; set; }
        public string bu { get; set; }
        public virtual pr_role pr_role { get; set; }
    }
}
