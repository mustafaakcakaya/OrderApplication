using CommonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Repository
{
    public interface IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<string> AddAsync(TEntity order);
        Task<bool> UpdateAsync(TEntity order);
        Task<bool> DeleteAsync(string id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(string id);
    }
}
