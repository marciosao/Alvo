using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity ObtemPorId(int id);

        TEntity AddWithReturn(TEntity obj);

        IEnumerable<TEntity> ObtemTodos();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
