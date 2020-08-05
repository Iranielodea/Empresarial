using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioPermissao : IRepositorioBase<Permissao>
    {
        IEnumerable<PermissaoConsulta> Filtrar(PermissaoFiltro filtro);
    }
}
