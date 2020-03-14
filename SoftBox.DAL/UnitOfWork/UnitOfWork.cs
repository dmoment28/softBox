﻿using Microsoft.EntityFrameworkCore;
using SoftBox.DAL.Repository;
using System.Threading.Tasks;

namespace SoftBox.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context.Set<TEntity>());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
