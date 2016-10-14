using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity:class
    {
        void Add(TEntity obj);

        TEntity AddWithReturn(TEntity obj);

        TEntity ObtemPorId(int id);

        IEnumerable<TEntity> ObtemTodos();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
