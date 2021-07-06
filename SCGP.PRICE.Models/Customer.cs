using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models
{
    public class Customer : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public string Description { get; set; }

        public Customer()
        {
            created_date = DateTime.Now;
            updated_date = DateTime.Now;
        }
    }
}
