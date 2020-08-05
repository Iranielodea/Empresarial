using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioEstado : IRepositorioBase<Estado>
    {
        IEnumerable<EstadoConsulta> Filtrar(EstadoFiltro filtro);
    }
}
