using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoOrganizacao : IServicoBase<Organizacao>
    {
        void Novo(int empresaId, int usuarioId);
        Organizacao ObterPorId(int id);
        Organizacao Editar(int empresaId, int usuarioId, int id);
        IEnumerable<OrganizacaoConsulta> Filtrar(OrganizacaoFiltro filtro);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(Organizacao model);
        void Relatorio(int empresaId, int usuarioId);
    }
}
