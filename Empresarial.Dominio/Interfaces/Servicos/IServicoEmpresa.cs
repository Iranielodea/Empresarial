using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoEmpresa : IServicoBase<Empresa>
    {
        void Novo(int empresaId, int usuarioId);
        Empresa ObterPorId(int id);
        Empresa Editar(int empresaId, int usuarioId, int id);
        IEnumerable<EmpresaConsulta> Filtrar(EmpresaFiltro filtro);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(Empresa model);
        void Relatorio(int empresaId, int usuarioId);
    }
}
