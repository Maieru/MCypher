﻿using Database.Context;
using Database.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal readonly DatabaseContext _context;
        internal readonly DbSet<TEntity> _dbSet;

        public Repository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException("context was null");
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                return await SaveAsync();
            }

            throw new EntityNotFoundException($"No entity of type {typeof(TEntity).Name} with {id} found");
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new EntityNotFoundException($"No entity of type {typeof(TEntity).Name} with {id} found");

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(bool tracked = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, bool tracked = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
                query = query.AsNoTracking();

            return await query.Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, int take, int skip, bool tracked = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracked)
                query = query.AsNoTracking();

            return await query.Where(filter).Skip(skip).Take(take).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
