using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoBase<T> : IDisposable, IServicoBase<T> where T : class
    {
        private readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Deletar(T entidade)
        {
            _repositorio.Deletar(entidade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public T Find(params object[] key)
        {
            return _repositorio.Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _repositorio.First(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return GetAll();
        }

        public void Insert(T entidade)
        {
            _repositorio.Insert(entidade);
        }

        public void SaveChanges()
        {
            _repositorio.SaveChanges();
        }

        public void Update(T entidade)
        {
            _repositorio.Update(entidade);
        }
    }
}
