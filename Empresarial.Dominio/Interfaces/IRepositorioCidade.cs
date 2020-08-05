using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioCidade : IRepositorioBase<Cidade>
    {
        IEnumerable<CidadeConsulta> Filtrar(CidadeFiltro filtro);
    }
}
