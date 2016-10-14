using Aplicacao.Interfaces;
using Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Aplicacao
{
    public class AppServicoBase<TEntity> : IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _serviceBase;

        public AppServicoBase(IServicoBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public TEntity ObtemPorId(int id)
        {
            return _serviceBase.ObtemPorId(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return _serviceBase.ObtemTodos();
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
