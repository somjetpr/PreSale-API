using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
  public   class CostModel
    {
        public int Id { get; set; }
        public string Costname { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal priceCost { get; set; }

    }
}
