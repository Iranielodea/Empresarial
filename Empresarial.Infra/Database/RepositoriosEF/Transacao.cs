using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class Transacao : ITransacao
    {
        private readonly Contexto _contexto;

        public Transacao(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void BeginTransaction()
        {
            _contexto.Database.BeginTransaction();
        }

        public void Commit()
        {
            _contexto.Database.CommitTransaction();
        }

        public void RoolBack()
        {
            _contexto.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }
    }
}
