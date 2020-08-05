using System;
using System.Linq;
using System.Linq.Expressions;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        T Find(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Insert(T entidade);
        void Update(T entidade);
        void Deletar(T entidade);
        void SaveChanges();
        void Dispose();
    }
}
