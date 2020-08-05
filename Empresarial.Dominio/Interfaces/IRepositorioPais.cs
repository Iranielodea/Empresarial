using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioPais : IRepositorioBase<Pais>
    {
        IEnumerable<PaisConsulta> Filtrar(PaisFiltro filtro);
    }
}
