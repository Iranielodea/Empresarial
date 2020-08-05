using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Empresarial.Dominio.Interfaces
{
    public interface IUsuarioIdentity
    {
        int IdUsuario { get; }
        int IdEmpresa { get; }
        int IdOrganizacao { get; }
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
