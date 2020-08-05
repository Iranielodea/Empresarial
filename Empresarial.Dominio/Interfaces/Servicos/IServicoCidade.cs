using Empresarial.Dominio.Entidades;
using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoCidade : IServicoBase<Cidade>
    {
        void Novo(int empresaId, int usuarioId);
        Cidade ObterPorId(int id);
        Cidade Editar(int empresaId, int usuarioId, int id);
        IEnumerable<CidadeConsulta> Filtrar(CidadeFiltro filtro);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(Cidade model);
        void Relatorio(int empresaId, int usuarioId);
    }
}
