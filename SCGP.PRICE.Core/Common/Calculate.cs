using org.mariuszgromada.math.mxparser;
using SCGP.PRICE.Models;
using SCGP.PRICE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE
{
    public class Calculate
    {

        /// <summary>
        /// Calculate RM Cost
        /// </summary>
        /// <param name="formulaKey"></param>
        /// <param name="verder"></param>
        /// <param name="rmGroup"></param>
        /// <returns></returns>
        public static double RMCost(string verder, string rmGroup, string formula ,List<VariableCal> variables,PriceCalcModel priceCalc)
        {
            try
            {
                PriceCalcModel priceCalc1 = new PriceCalcModel
                {
                    page = 1000,
                    gear = 1000,
                    gram = 200,
                    dclass = 2
                };
                List<VariableCal> variabllist = new List<VariableCal>();
                variabllist.Add(new VariableCal { Id = 1, ColumnName = "page" });
                variabllist.Add(new VariableCal { Id = 2, ColumnName = "gear" });
                variabllist.Add(new VariableCal { Id = 3, ColumnName = "gram" });
                variabllist.Add(new VariableCal { Id = 4, ColumnName = "class" });
                

                formula = "(page*gear*gram*strclass)/10000";
                Expression e = new Expression(formula);
                PropertyInfo[] props = typeof(PriceCalcModel).GetProperties();

                Type myClassType = priceCalc1.GetType();
                PropertyInfo[] properties = myClassType.GetProperties();
                var res = new PriceCalcModel();
                //var variable = new List<string>() { "a", "b", "c" };

                foreach (var variableItem in variabllist)
                {
                    foreach (PropertyInfo property in properties)
                    {

                       double c = (double)property.GetValue(priceCalc1, null);
                        if (variableItem.ColumnName == property.Name)
                        {
                            e.addArguments(new Argument(variableItem.ColumnName, c));
                        }
                    }
                }
                //for (int i = 0; i < variables.Count; i++)
                //{
                //    e.addArguments(new Argument(myMacth[i], 100));
                //}

                //e.addArguments(a, b);
                double v = e.calculate();
                return v;
                //return createPrefixed((sysLastedKey ?? ""),
                //    (sysPrefixKey ?? ""), (sysFormatKey ?? ""), (sysLenghtKey ?? 0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string OnCreatePrefixed(string sysLastedKey, string sysPrefixKey, string sysFormatKey, int? sysLenghtKey)
        {
            try
            {

                return createPrefixed((sysLastedKey ?? ""),
                    (sysPrefixKey ?? ""), (sysFormatKey ?? ""), (sysLenghtKey ?? 0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> OnCreatePrefixed(string sysLastedKey, string sysPrefixKey, string sysFormatKey, int? sysLengthKey, int Count)
        {
            try
            {
                List<string> _keyNo = new List<string>();
                int _lastSequence = 0;
                string _sysPrefixkey = (sysPrefixKey ?? "");
                string _sysFormatKey = (sysFormatKey ?? "");
                string _resultFormatKey = "";

                CultureInfo cultureinfo = new CultureInfo("en-US");
                DateTime dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd", cultureinfo));
                if (!string.IsNullOrEmpty(_sysFormatKey))
                    _resultFormatKey = dt.ToString(_sysFormatKey);

                StringBuilder _key = new StringBuilder();
                for (int index = 0; index < sysLengthKey.Value; index++)
                {
                    _key.Append("0");
                }

                if (!string.IsNullOrWhiteSpace(sysLastedKey))
                    _lastSequence = int.Parse(sysLastedKey.Substring(_sysPrefixkey.Length + _sysFormatKey.Length));

                for (int index = 1; index <= Count; index++)
                {
                    var _lastKeyNo = _sysPrefixkey + _resultFormatKey + _lastSequence.ToString(_key.ToString());
                    _keyNo.Add(createPrefixed((_lastKeyNo ?? ""), (sysPrefixKey ?? ""), (sysFormatKey ?? ""), (sysLengthKey ?? 0)));
                    _lastSequence += 1;
                }

                return _keyNo;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private static string createPrefixed(string sysLastKey, string sysPrefixKey, string sysFormatKey, int sysLengthKey)
        {
            StringBuilder key = new StringBuilder();
            string AutoNo = string.Empty;
            string resultFormatKey = string.Empty;
            string Sequence = string.Empty;
            string lastFormatKey = string.Empty;
            string NewKey;
            try
            {

                string lastKeyNo = sysLastKey;
                string prefixKey = sysPrefixKey;
                int Lenght = sysLengthKey;

                for (int index = 0; index < Lenght; index++)
                {
                    key.Append("0");
                }

                if (!string.IsNullOrEmpty(sysFormatKey))
                {
                    CultureInfo cultureinfo = new CultureInfo("en-US");
                    DateTime dt = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd", cultureinfo));

                    resultFormatKey = dt.ToString(sysFormatKey);

                    if (!string.IsNullOrEmpty(lastKeyNo))
                    {
                        lastFormatKey = lastKeyNo.Substring(prefixKey.Length, sysFormatKey.Length);
                        if (int.Parse(resultFormatKey.Replace("-", "")) > int.Parse(lastFormatKey.Replace("-", "")))
                        {
                            NewKey = genNewKey(prefixKey, resultFormatKey, key.ToString());
                        }
                        else
                        {
                            NewKey = genKey(prefixKey, sysLastKey, lastFormatKey, key.ToString());
                        }
                    }
                    else
                    {
                        NewKey = genNewKey(prefixKey, resultFormatKey, key.ToString());
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(lastKeyNo))
                        NewKey = genKey(prefixKey, sysLastKey, sysFormatKey, key.ToString());
                    else
                        NewKey = genNewKey(prefixKey, sysFormatKey, key.ToString());
                }

                return NewKey;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string genNewKey(string prefixKey, string FormatKey, string key)
        {
            int lastSequence = 1;
            string Sequence = lastSequence.ToString(key);
            var _lastKeyNo = prefixKey + FormatKey + Sequence;
            return _lastKeyNo;
        }

        private static string genKey(string prefixKey, string lastKeyNo, string FormatKey, string key)
        {
            int lastSequence = int.Parse(lastKeyNo.Substring((prefixKey + FormatKey).Length)) + 1;
            string Sequence = lastSequence.ToString(key.ToString());
            var _lastKeyNo = prefixKey + FormatKey + Sequence;
            return _lastKeyNo;
        }

        public static string LotGenerater(string lastNo)
        {
            string year = DateTime.Now.Year.ToString("0000");
            string month = DateTime.Now.Month.ToString("00");
            string week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString("00");
            string _y = lastNo.Substring(1, 4);
            string _m = lastNo.Substring(5, 2);
            string no = "00001";
            string lotNo = string.Empty;
            if(string.IsNullOrEmpty(lastNo))
                return year + month + week + no;

            if (year != _y)
            {
                lotNo = year + month + week + no;
            }            
            else
            {
                if (month != _m)
                    lotNo = year + month + week + no;
                else
                {
                    no = lastNo.Substring(8, 5);
                    lotNo = year + month + week + no;
                }
            }

            return lotNo;
        }

        public static string BatchGenerater(string lastBatchNo)
        {
            string year = DateTime.Now.Year.ToString("0000");
            string month = DateTime.Now.Month.ToString("00");
            string week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString("00");
            string monthweek = month + week;
            string _y = lastBatchNo.Substring(1, 4);
            string _mw = lastBatchNo.Substring(5, 4);
            string no = "00001";
            string batchNo = string.Empty;
            if (string.IsNullOrEmpty(lastBatchNo))
                return year + month + week + no;

            if (year != _y)
            {
                batchNo = year + monthweek + no;
            }
            else
            {
                if (monthweek != _mw)
                    batchNo = year + monthweek + no;
                else
                {
                    no = lastBatchNo.Substring(8, 5);
                    var _no = (int.Parse(no) + 1).ToString("00000");
                    batchNo = year + monthweek + _no;
                }
            }

            return batchNo;
        }
    }
}
