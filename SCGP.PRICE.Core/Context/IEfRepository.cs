using SCGP.PRICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.Context
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }
        Task<T> FindByIdAsync(object id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
