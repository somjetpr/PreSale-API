using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class pr_role : BaseEntity
    {
        public string name { get; set; }
        public virtual ICollection<pr_user> users { get; set; }
        public pr_role()
        {
            users = new List<pr_user>();
        }
    }
}
