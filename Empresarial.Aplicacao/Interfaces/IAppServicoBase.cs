using System;
using System.Linq;
using System.Linq.Expressions;

namespace Empresarial.Aplicacao.Interfaces
{
    public interface IAppServicoBase<T> where T : class
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
