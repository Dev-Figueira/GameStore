using GameStore.Data.Context;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly GameStoreDbContex Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(GameStoreDbContex db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            Db.Entry(new TEntity { Id = id }).State = EntityState.Detached;
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DetachLocal(entity);
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DetachLocal(entity);
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DetachLocal(new TEntity { Id = id });
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual void DetachLocal(TEntity entity)
        {
            var local = DbSet.Local.FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            Db.Entry(entity).State = EntityState.Detached;

            if (local != null)
            {
                Db.Entry(local).State = EntityState.Detached;
            }
            else
            {
                var entry = Db.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
