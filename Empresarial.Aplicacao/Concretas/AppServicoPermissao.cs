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
    public class AppServicoPermissao : AppServicoBase<Permissao>, IAppServicoPermissao
    {
        private readonly IServicoPermissao _servico;
        private readonly ITransacao _transacao;
        private INotificacao _notificacao;

        public AppServicoPermissao(IServicoPermissao servico, ITransacao transacao,
            INotificacao notificacao)
            : base(servico, transacao)
        {
            _servico = servico;
            _transacao = transacao;
            _notificacao = notificacao;
        }

        public IEnumerable<PermissaoConsultaModel> Filtrar(PermissaoFiltro filtro)
        {
            var lista = _servico.Filtrar(filtro);
            var viewModel = lista.Adapt<PermissaoConsultaModel[]>();
            return viewModel;
        }

        public PermissaoModel Novo(int empresaId, int usuarioId)
        {
            _servico.Novo(empresaId, usuarioId);
            return new PermissaoModel();
        }

        public PermissaoModel ObterPorId(int id)
        {
            var model = _servico.Find(id);
            var viewModel = model.Adapt<PermissaoModel>();
            return viewModel;
        }

        public PermissaoModel Editar(int empresaId, int usuarioId, int id)
        {
            var model = _servico.Editar(empresaId, usuarioId, id);
            var viewModel = model.Adapt<PermissaoModel>();
            return viewModel;
        }

        public void Salvar(PermissaoModel model)
        {
            try
            {
                var dados = model.Adapt<Permissao>();
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
