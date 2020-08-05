using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioEmpresa : IRepositorioBase<Empresa>
    {
        IEnumerable<EmpresaConsulta> Filtrar(EmpresaFiltro filtro);
    }
}
