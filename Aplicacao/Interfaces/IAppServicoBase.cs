using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface IAppServicoBase<TEntity> where TEntity:class
    {
        void Add(TEntity obj);

        TEntity ObtemPorId(int id);

        IEnumerable<TEntity> ObtemTodos();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
