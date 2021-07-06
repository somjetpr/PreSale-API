using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Core.BL
{
    public interface IBaseBLL : IDisposable
    {
        string UserName { get; set; }
    }
}
