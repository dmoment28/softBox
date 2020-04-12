using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace SoftBox.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entity);
    }
}
