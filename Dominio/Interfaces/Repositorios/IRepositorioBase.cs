using System.Collections.Generic;
using System.Data.Entity;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity ObtemPorId(int id);

        TEntity AddWithReturn(TEntity obj);

        IEnumerable<TEntity> ObtemTodos();

        DbSet<TEntity> Entidade();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
