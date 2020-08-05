using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoPrograma : IServicoBase<Programa>
    {
        void Novo(int empresaId, int usuarioId);
        Programa ObterPorId(int id);
        Programa Editar(int empresaId, int usuarioId, int id);
        IEnumerable<ProgramaConsulta> Filtrar(ProgramaFiltro filtro);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(Programa model);
        void Relatorio(int empresaId, int usuarioId);
    }
}
