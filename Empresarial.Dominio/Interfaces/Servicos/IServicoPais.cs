using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoPais : IServicoBase<Pais>, IServicoBasePadrao<Pais>
    {
        IEnumerable<PaisConsulta> Filtrar(PaisFiltro filtro);
    }
}
