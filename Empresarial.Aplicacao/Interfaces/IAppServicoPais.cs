using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Model;
using System.Collections.Generic;

namespace Empresarial.Aplicacao.Interfaces
{
    public interface IAppServicoPais : IAppServicoBase<Pais>, IAppServicoBasePadrao<PaisModel>
    {
        IEnumerable<PaisConsultaModel> Filtrar(PaisFiltro filtro);
    }
}
