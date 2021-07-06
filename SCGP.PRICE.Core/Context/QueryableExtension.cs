using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.Context
{
    /// </summary>
    public static class QueryableExtensions
    {  
        public static IQueryable<T> Get<T>(this IQueryable<T> queryable, out int totalRecords, int? skip = null, int? take = null)
        {
            if (queryable == null)
                throw new ArgumentNullException(nameof(queryable));

            totalRecords = queryable.Count();
            take = (take == 0 ? null : take); 
            if (take != null)
                queryable = queryable.Skip((skip.Value - 1) * take.Value).Take(take.Value);

            return queryable;
        }
    }
}
