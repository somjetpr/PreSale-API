using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace SCGP.PRICE.Models.ViewModel
{
    public class PriceCalcModel
    {
        public double page { get; set; }
        public double gear { get; set; }
        public double gram { get; set; }
        public double dclass { get; set; }

        public double tube { get; set; }
        public double waste { get; set; }
        public double netweight { get; set; }
        public double LP { get; set; }

    }
}
