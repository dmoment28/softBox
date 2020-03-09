using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftBox.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
