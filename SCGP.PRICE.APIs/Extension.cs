using SCGP.PRICE.Core.BL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCGP.PRICE.APIs
{
    public static class Extension
    {
        public static HttpCustomHeaders CustomRequest(this HttpRequest request)
        {
            HttpCustomHeaders headers = new HttpCustomHeaders();

            headers.Secret = request.Headers["Secret"].ToString();
            headers.UserName = request.Headers["UserName"].ToString();

            return headers;
        }


        //public static DataSourceLoadOptions TryParseParams(this HttpRequest request)
        //{
        //    try
        //    {
        //        return  JsonSerializer.Deserialize<DataSourceLoadOptions>(request.Query["query"][0]);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }

}
