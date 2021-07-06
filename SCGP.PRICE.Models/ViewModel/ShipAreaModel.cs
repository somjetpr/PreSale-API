using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class ShipAreaModel
    {
        public int shipAreaId { get; set; }
        public double QtyForwardingTrip { get; set; }
    }
}
