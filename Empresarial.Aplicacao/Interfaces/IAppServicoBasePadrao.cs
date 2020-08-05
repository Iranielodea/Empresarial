using Empresarial.Dominio.Interfaces;

namespace Empresarial.Aplicacao.Interfaces
{
    public interface IAppServicoBasePadrao<T> where T : class
    {
        T Novo(int empresaId, int usuarioId);
        T Editar(int empresaId, int usuarioId, int id);
        T ObterPorId(int id);
        void Salvar(T viewModel);
        void Excluir(int empresaId, int usuarioId, int id);        
        void Relatorio(int empresaId, int usuarioId);
        INotificacao Notificacao();
    }
}
