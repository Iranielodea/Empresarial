using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioOrganizacao : RepositorioBase<Organizacao>, IRepositorioOrganizacao
    {
        Contexto _contexto;
        public RepositorioOrganizacao(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<OrganizacaoConsulta> Filtrar(OrganizacaoFiltro filtro)
        {
            var resultado = from p in _contexto.Organizacoes
                            select new
                            {
                                id = p.Id,
                                nome = p.Nome,
                                ativo = p.Ativo
                            };
            resultado = resultado.Where(x => x.nome.Contains(filtro.Valor));

            if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
            {
                if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
                    resultado = resultado.Where(x => x.ativo == true);
                else
                    resultado = resultado.Where(x => x.ativo == false);
            }

            var lista = new List<OrganizacaoConsulta>();

            foreach (var item in resultado)
            {
                lista.Add(new OrganizacaoConsulta() { Id = item.id, Nome = item.nome});
            }

            return lista;
        }
    }
}
