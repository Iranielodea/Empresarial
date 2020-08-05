using Empresarial.Aplicacao.Interfaces;
using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using Empresarial.Dominio.Model;
using Mapster;
using System;
using System.Collections.Generic;

namespace Empresarial.Aplicacao.Concretas
{
    public class AppServicoPais : AppServicoBase<Pais>, IAppServicoPais
    {
        private readonly IServicoPais _servico;
        private readonly ITransacao _transacao;
        private readonly INotificacao _notificacao;

        public AppServicoPais(IServicoPais servico, ITransacao transacao,
            INotificacao notificacao)
            : base(servico, transacao)
        {
            _servico = servico;
            _transacao = transacao;
            _notificacao = notificacao;
        }

        public IEnumerable<PaisConsultaModel> Filtrar(PaisFiltro filtro)
        {
            var lista = _servico.Filtrar(filtro);
            var resultado = lista.Adapt<PaisConsultaModel[]>();
            return resultado;
        }

        public PaisModel Novo(int empresaId, int usuarioId)
        {
            _servico.Novo(empresaId, usuarioId);
            return new PaisModel();
        }

        public PaisModel ObterPorId(int id)
        {
            var model = _servico.Find(id);
            var retorno = model.Adapt<PaisModel>();
            return retorno;
        }

        public PaisModel Editar(int empresaId, int usuarioId, int id)
        {
            var model = _servico.Editar(empresaId, usuarioId, id);
            var retorno = model.Adapt<PaisModel>();

            return retorno;
        }

        public void Salvar(PaisModel model)
        {
            try
            {
                var dados = model.Adapt<Pais>();
                _servico.Salvar(dados);

                if (_servico.Notificacao().IsValid())
                    _transacao.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int empresaId, int usuarioId, int id)
        {
            try
            {
                _servico.Excluir(empresaId, usuarioId, id);
                _transacao.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Relatorio(int empresaId, int usuarioId)
        {
            _servico.Relatorio(empresaId, usuarioId);
        }

        public INotificacao Notificacao()
        {
            return _notificacao;
        }
    }
}
