using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoEstado : IServicoBase<Estado>
    {
        void Novo(int empresaId, int usuarioId);
        Estado ObterPorId(int id);
        Estado Editar(int empresaId, int usuarioId, int id);
        IEnumerable<EstadoConsulta> Filtrar(EstadoFiltro filtro);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(Estado model);
        void Relatorio(int empresaId, int usuarioId);
        Estado ObterPorSigla(string sigla);
    }
}
