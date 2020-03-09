using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SoftBox.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        private readonly DbSet<TEntity> _dbSet;

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new Exception();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
