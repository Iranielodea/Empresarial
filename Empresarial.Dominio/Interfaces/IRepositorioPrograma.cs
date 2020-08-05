using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioPrograma : IRepositorioBase<Programa>
    {
        IEnumerable<ProgramaConsulta> Filtrar(ProgramaFiltro filtro);
    }
}
