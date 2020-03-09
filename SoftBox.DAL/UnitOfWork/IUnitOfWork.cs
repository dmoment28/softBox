using System;
using System.Threading.Tasks;
using SoftBox.DAL.Repository;

namespace SoftBox.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
