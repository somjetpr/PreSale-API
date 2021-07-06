using SCGP.PRICE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCGP.PRICE.Core.Context
{
    public class EfRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        protected SCGPDbContext context;

        public IQueryable<T> Table { get => context.Set<T>().AsQueryable(); }

        public EfRepository(SCGPDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<bool> AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<T> FindByIdAsync(object id) => await context.Set<T>().FindAsync(id);
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().FirstOrDefaultAsync(predicate);
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) => context.Set<T>().Where(predicate).AsEnumerable();

    }
}
