using Microsoft.EntityFrameworkCore;
using ProjectManager.Infrastructure.Data.DatabaseContext;
using ProjectManager.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Repository.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext _applicationDbContext)
        {
            ApplicationDbContext = _applicationDbContext;
        }

        public async Task Create(T Entity)
        {
            await ApplicationDbContext.Set<T>().AddAsync(Entity);
        }

        public async Task Delete(T Entity)
        {
            ApplicationDbContext.Set<T>().Remove(Entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await ApplicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetManyByCondition(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task Update(T Entity)
        {
            ApplicationDbContext.Set<T>().Update(Entity);
        }        

        public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
    }
}
