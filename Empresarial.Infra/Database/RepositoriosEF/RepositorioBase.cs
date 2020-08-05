using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Empresarial.Infra.RepositoriosEF
{
    public class RepositorioBase<T> : IRepositorioBase<T>, IDisposable where T : class
    {
        private readonly Contexto _contexto;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }
        public void Deletar(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
        }

        public void Dispose()
        {
            if (_contexto != null)
                _contexto.Dispose();
            GC.SuppressFinalize(this);
        }

        public T Find(params object[] key)
        {
            return _contexto.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _contexto.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _contexto.Set<T>();
        }

        public void Insert(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }

        public void Update(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
        }
    }
}
