using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Model;
using System.Collections.Generic;

namespace Empresarial.Aplicacao.Interfaces
{
    public interface IAppServicoPermissao : IAppServicoBase<Permissao>, IAppServicoBasePadrao<PermissaoModel>
    {
        IEnumerable<PermissaoConsultaModel> Filtrar(PermissaoFiltro filtro);
    }
}
