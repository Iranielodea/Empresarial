using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro);
    }
}
