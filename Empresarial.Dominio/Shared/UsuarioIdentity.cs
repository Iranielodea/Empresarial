using Empresarial.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Empresarial.Dominio.Shared
{
    public class UsuarioIdentity : IUsuarioIdentity
    {
        private readonly IHttpContextAccessor _accessor;

        public UsuarioIdentity(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public int IdUsuario => int.Parse(GetClaimsIdentity().FirstOrDefault(x => x.Type == "ID")?.Value);

        public int IdEmpresa => int.Parse(GetClaimsIdentity().FirstOrDefault(x => x.Type == "EMPRESA")?.Value);

        public int IdOrganizacao => int.Parse(GetClaimsIdentity().FirstOrDefault(x => x.Type == "ORGANIZACAO")?.Value);

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
