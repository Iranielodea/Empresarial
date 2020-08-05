using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioOrganizacao : IRepositorioBase<Organizacao>
    {
        IEnumerable<OrganizacaoConsulta> Filtrar(OrganizacaoFiltro filtro);
    }
}
