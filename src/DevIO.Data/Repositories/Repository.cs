using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(MeuDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<int> Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            return await SaveChanges();
        }

        public virtual async Task<int> Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveChanges();
        }

        public virtual async Task<int> Remover(Guid id)
        {
            var entity = new TEntity{ Id = id};
            _dbSet.Remove(entity);
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
