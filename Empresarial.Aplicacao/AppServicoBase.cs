using Empresarial.Aplicacao.Interfaces;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Empresarial.Aplicacao
{
    public class AppServicoBase<T> : IDisposable, IAppServicoBase<T> where T : class
    {
        private readonly IServicoBase<T> _servico;
        private readonly ITransacao _transacao;
        public AppServicoBase(IServicoBase<T> servico, ITransacao transacao)
        {
            _servico = servico;
            _transacao = transacao;
        }

        public void Deletar(T entidade)
        {
            _servico.Deletar(entidade);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }

        public T Find(params object[] key)
        {
            return _servico.Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _servico.First(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _servico.GetAll();
        }

        public void Insert(T entidade)
        {
            _servico.Insert(entidade);
        }

        public void SaveChanges()
        {
            _servico.SaveChanges();
        }

        public void Update(T entidade)
        {
            _servico.Update(entidade);
        }
    }
}
