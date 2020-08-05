using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioUsuarioEmpresa : RepositorioBase<UsuarioEmpresa>, IRepositorioUsuarioEmpresa
    {
        public RepositorioUsuarioEmpresa(Contexto contexto) : base(contexto)
        {
        }
    }
}
