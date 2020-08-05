using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioPais : RepositorioBase<Pais>, IRepositorioPais
    {
        private readonly Contexto _contexto;
        private readonly IRepositorioPaisAlt _repositorioAlt;

        public RepositorioPais(Contexto contexto,
            IRepositorioPaisAlt repositorioAlt) : base(contexto)
        {
            _contexto = contexto;
            _repositorioAlt = repositorioAlt;
        }

        public IEnumerable<PaisConsulta> Filtrar(PaisFiltro filtro)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT ID, NOME, ATIVO FROM paises ");
            sb.AppendLine(" WHERE " + filtro.Campo + " like '%" + filtro.Valor + "%'");
            if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
            {
                if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
                    sb.AppendLine(" AND ATIVO = 1");
                else
                    sb.AppendLine(" AND ATIVO = 0");
            }

            return _repositorioAlt.RetornarTodos(sb.ToString());
        }
    }
}
