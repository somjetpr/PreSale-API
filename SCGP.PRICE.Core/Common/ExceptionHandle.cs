using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE
{
    public static class ExceptionHandle
    {
        
        public static Exception GetFullErrorText(this Exception ex)
        {
            var messages = ex.FromHierarchy(e => e.InnerException)
                .Select(e => e.Message);

            return new Exception(String.Join(Environment.NewLine, messages));

        }


        private static IEnumerable<TSource> FromHierarchy<TSource>(
           this TSource source,
           Func<TSource, TSource> nextItem)
           where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(
                     this TSource source,
                     Func<TSource, TSource> nextItem,
                     Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

    }
}
