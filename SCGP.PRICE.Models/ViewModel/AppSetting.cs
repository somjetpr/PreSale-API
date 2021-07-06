using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{

    public class AppSetting
    {
        public string Secret { get; set; }
        public string UserName { get; set; }
        public bool IsDevelopment { get; set; }
        public bool IsWMSInterface { get; set; }
        public string Clients { get; set; }
        public string WMSInterfaceUri { get; set; }
        public bool IsERPInterface { get; set; }
        public string ERPInterfaceUri { get; set; }
        public string NewCustomerFilePath { get; set; }
        public string SaleOrderFilePath { get; set; }
    }

}
