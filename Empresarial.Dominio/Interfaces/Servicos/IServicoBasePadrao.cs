namespace Empresarial.Dominio.Interfaces.Servicos
{
    public interface IServicoBasePadrao<T> where T : class
    {
        T Novo(int empresaId, int usuarioId);
        T Editar(int empresaId, int usuarioId, int id);
        void Excluir(int empresaId, int usuarioId, int id);
        void Salvar(T model);
        void Relatorio(int empresaId, int usuarioId);
        INotificacao Notificacao();
    }
}
