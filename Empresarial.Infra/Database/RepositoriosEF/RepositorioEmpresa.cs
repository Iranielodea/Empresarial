using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioEmpresa : RepositorioBase<Empresa>, IRepositorioEmpresa
    {
        Contexto _contexto;
        public RepositorioEmpresa(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<EmpresaConsulta> Filtrar(EmpresaFiltro filtro)
        {
            var resultado = from c in _contexto.Empresas
                            join o in _contexto.Organizacoes on c.OrganizacaoId equals o.Id
                            where(c.OrganizacaoId == filtro.OrganizacaoId)
                            select new
                            {
                                id = c.Id,
                                nome = c.Nome,
                                nomeOrganizacao = o.Nome,
                                ativo = c.Ativo
                            };

            resultado = resultado.Where(x => x.nome.Contains(filtro.Valor));

            if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
            {
                if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
                    resultado = resultado.Where(x => x.ativo == true);
                else
                    resultado = resultado.Where(x => x.ativo == false);
            }

            var lista = new List<EmpresaConsulta>();

            foreach (var item in resultado)
            {
                lista.Add(new EmpresaConsulta() { Id = item.id, Nome = item.nome });
            }

            return lista;
        }
    }
}
