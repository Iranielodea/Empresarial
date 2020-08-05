using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoPermissao : IServicoBase<Permissao>, IServicoBasePadrao<Permissao>
    {
        IEnumerable<PermissaoConsulta> Filtrar(PermissaoFiltro filtro);
        bool Permissao(int codigoPrograma, int empresaId, int usuarioId, EnPermissao enPermissao);
    }
}
