using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoPais : ServicoBase<Pais>, IServicoPais
    {
        private readonly IRepositorioPais _repositorio;
        private readonly IServicoPermissao _servicoPermissao;
        private INotificacao _notificacao;
        private readonly int _codigoPrograma;

        public ServicoPais(IRepositorioPais repositorio, IServicoPermissao servicoPermissao,
            INotificacao notificacao)
            :base(repositorio)
        {
            _repositorio = repositorio;
            _servicoPermissao = servicoPermissao;
            _notificacao = notificacao;
            _codigoPrograma = 1;
        }

        private void PermissaoAcao(int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = _servicoPermissao.Permissao(_codigoPrograma, empresaId, usuarioId, enPermissao);
            if (permissao == false)
                throw new Exception("Usuário sem Permissão!");
        }

        public Pais Editar(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Editar);
            return _repositorio.Find(id);
        }

        public void Excluir(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Excluir);

            var model = _repositorio.Find(id);
            if (model != null)
                _repositorio.Deletar(model);
        }

        public IEnumerable<PaisConsulta> Filtrar(PaisFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public Pais Novo(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Incluir);
            return new Pais(0, 0, "", 222, true);
        }

        public void Relatorio(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Relatorio);
        }

        private void Validar(Pais model)
        {
            var validacao = new PaisValidacao(model);

            if (validacao.Contract.Notifications.Count() > 0)
            {
                foreach (var notificacao in validacao.Contract.Notifications)
                    _notificacao.Adicionar(notificacao.Message);
            }

            //if (string.IsNullOrEmpty(model.Nome))
            //    _notificacao.Adicionar("Informe o Nome!");
        }

        public void Salvar(Pais model)
        {
            Validar(model);

            if (_notificacao.IsValid())
            {
                if (model.Id == 0)
                    _repositorio.Insert(model);
                else
                    _repositorio.Update(model);
            }
        }

        public INotificacao Notificacao()
        {
            return _notificacao;
        }
    }
}
