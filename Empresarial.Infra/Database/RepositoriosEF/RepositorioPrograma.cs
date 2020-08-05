using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioPrograma : RepositorioBase<Programa>, IRepositorioPrograma
    {
        Contexto _contexto;
        public RepositorioPrograma(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ProgramaConsulta> Filtrar(ProgramaFiltro filtro)
        {
            var resultado = from p in _contexto.Programas
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

            var lista = new List<ProgramaConsulta>();

            foreach (var item in resultado)
            {
                lista.Add(new ProgramaConsulta() { Id = item.id, Nome = item.nome});
            }

            return lista;
        }
    }
}
