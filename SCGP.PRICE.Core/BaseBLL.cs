using log4net.Core;
using SCGP.PRICE.Core.Context;
using SCGP.PRICE.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SCGP.PRICE.Core.BL
{
    public class BaseBLL : IBaseBLL
    {
        public string UserName { get; set; }
        public BaseBLL()
        {

            if (Utils.AppSetting.IsDevelopment)
                UserName = Utils.AppSetting.UserName;


        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
