using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioEstado : RepositorioBase<Estado>, IRepositorioEstado
    {
        Contexto _contexto;
        private readonly IRepositorioAlternativo<EstadoConsulta> _repositorio;
        public RepositorioEstado(Contexto contexto,
            IRepositorioAlternativo<EstadoConsulta> repositorio) : base(contexto)
        {
            _contexto = contexto;
            _repositorio = repositorio;
        }

        public IEnumerable<EstadoConsulta> Filtrar(EstadoFiltro filtro)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT ID, NOME, SIGLA, ATIVO FROM estados ");
            sb.AppendLine(" WHERE " + filtro.Campo + " like '%" + filtro.Valor + "%'");
            if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
            {
                if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
                    sb.AppendLine(" AND ATIVO = 1");
                else
                    sb.AppendLine(" AND ATIVO = 0");
            }

            return _repositorio.RetornarLista(sb.ToString());
        }
    }
}
