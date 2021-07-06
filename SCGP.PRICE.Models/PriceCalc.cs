using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace SCGP.PRICE.Models
{
    public class PriceCalc : BaseEntity
    {
        public double page { get; set; }
        public double gear { get; set; }
        public double gram { get; set; }
        public double dclass { get; set; }
    }
}
