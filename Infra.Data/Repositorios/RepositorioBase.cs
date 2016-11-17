using System;
using System.Collections.Generic;
using Dominio.Interfaces.Repositorios;
using Infra.Data.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {
        protected bdalvoContext Db = new bdalvoContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity ObtemPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public DbSet<TEntity> Entidade()
        {
            return Db.Set<TEntity>();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity AddWithReturn(TEntity obj)
        {
            try
            {
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
