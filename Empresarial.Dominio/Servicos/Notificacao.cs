using Empresarial.Dominio.Interfaces;
using System.Collections.Generic;

namespace Empresarial.Dominio.Servicos
{
    public class Notificacao : INotificacao
    {
        private List<string> _mensagem;

        public Notificacao()
        {
            _mensagem = new List<string>();
        }

        public void Adicionar(string mensagem)
        {
            _mensagem.Add(mensagem);
        }

        public bool IsValid()
        {
            return (_mensagem.Count == 0);
        }

        public List<string> RetornarErros()
        {
            return _mensagem;
        }
    }
}
