using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioCidade : RepositorioBase<Cidade>, IRepositorioCidade
    {
        Contexto _contexto;
        public RepositorioCidade(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<CidadeConsulta> Filtrar(CidadeFiltro filtro)
        {
            var resultado = from c in _contexto.Cidades
                            join e in _contexto.Estados on c.EstadoId equals e.Id
                            select new
                            {
                                id = c.Id,
                                nome = c.Nome,
                                sigla = e.Sigla,
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

            var lista = new List<CidadeConsulta>();

            foreach (var item in resultado)
            {
                lista.Add(new CidadeConsulta() { Id = item.id, Nome = item.nome, Sigla=item.sigla});
            }

            return lista;
        }
    }
}
