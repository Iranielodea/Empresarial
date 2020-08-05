using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface INotificacao
    {
        void Adicionar(string mensagem);
        bool IsValid();
        List<string> RetornarErros();
    }
}
