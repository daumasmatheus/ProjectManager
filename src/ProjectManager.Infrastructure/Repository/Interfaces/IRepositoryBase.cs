using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetManyByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression);
        Task Create(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity); 
    }
}
