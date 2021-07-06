using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCGP.PRICE
{
    public class Utils
    {
        public static AppSetting AppSetting { get; set; }
        public static string ConnectionString { get; set; }

        internal static double ConvertToDouble(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }
    }

    public static class Extension
    {
        public static T ToEnum<T>(this string obj)
        {
            var result = (T)Enum.Parse(typeof(T), obj);
            return result;
        }


        public static string StringValueOf(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        //public static async Task<ResponseViewModel<T>> ToResultAsync<T>(this DevExtreme.AspNet.Data.ResponseModel.LoadResult result)
        //{
        //    return await Task.Run(() =>
        //    {
        //        return new ResponseViewModel<T>
        //        {
        //            data = result.data.Cast<T>().ToList(),
        //            totalCount = result.totalCount
        //        };
        //    });
        //}
    }
}