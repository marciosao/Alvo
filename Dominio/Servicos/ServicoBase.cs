using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repository;

        public ServicoBase(IRepositorioBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public TEntity AddWithReturn(TEntity obj)
        {
            return _repository.AddWithReturn(obj);
        }

        public TEntity ObtemPorId(int id)
        {
            return _repository.ObtemPorId(id);
        }

        public IEnumerable<TEntity> ObtemTodos()
        {
            return _repository.ObtemTodos();
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
