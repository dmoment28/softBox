using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SoftBox.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(int id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
