using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoPermissao : ServicoBase<Permissao>, IServicoPermissao
    {
        private readonly IRepositorioPermissao _repositorio;
        private INotificacao _notificacao;
        private readonly IUsuarioIdentity _usuarioIdentity;
        private readonly int _codigoPrograma;

        public ServicoPermissao(IRepositorioPermissao repositorio,
            INotificacao notificacao, IUsuarioIdentity usuarioIdentity)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _notificacao = notificacao;
            _usuarioIdentity = usuarioIdentity;
            _codigoPrograma = 3;
        }

        private void PermissaoAcao(int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = Permissao(_codigoPrograma, _usuarioIdentity.IdEmpresa, _usuarioIdentity.IdUsuario, enPermissao);
            if (permissao == false)
                throw new Exception("Usuário sem Permissão!");
        }

        public Permissao Editar(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(_usuarioIdentity.IdEmpresa, _usuarioIdentity.IdUsuario, EnPermissao.Editar);
            return _repositorio.Find(id);
        }

        public void Excluir(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(_usuarioIdentity.IdEmpresa, _usuarioIdentity.IdUsuario, EnPermissao.Excluir);

            var model = _repositorio.Find(id);
            if (model != null)
            {
                _repositorio.Deletar(model);
            }
        }

        public IEnumerable<PermissaoConsulta> Filtrar(PermissaoFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public Permissao Novo(int empresaId, int usuarioId)
        {
            PermissaoAcao(_usuarioIdentity.IdEmpresa, _usuarioIdentity.IdUsuario, EnPermissao.Incluir);
            return new Permissao();
        }

        public bool Permissao(int codigoPrograma, int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = true;

            if (enPermissao == EnPermissao.Acesso)
            {
                permissao = _repositorio.GetAll().Any(x => x.Programa.Codigo == codigoPrograma
                && x.UsuarioId == _usuarioIdentity.IdUsuario
                && x.EmpresaId == _usuarioIdentity.IdEmpresa
                && x.Acesso == true);
            }

            if (enPermissao == EnPermissao.Incluir)
            {
                permissao = _repositorio.GetAll().Any(x => x.Programa.Codigo == codigoPrograma
                && x.UsuarioId == _usuarioIdentity.IdUsuario
                && x.EmpresaId == _usuarioIdentity.IdEmpresa
                && x.Incluir == true);
            }

            if (enPermissao == EnPermissao.Editar)
            {
                permissao = _repositorio.GetAll().Any(x => x.Programa.Codigo == codigoPrograma
                && x.UsuarioId == _usuarioIdentity.IdUsuario
                && x.EmpresaId == _usuarioIdentity.IdEmpresa
                && x.Editar == true);
            }

            if (enPermissao == EnPermissao.Excluir)
            {
                permissao = _repositorio.GetAll().Any(x => x.Programa.Codigo == codigoPrograma
                && x.UsuarioId == _usuarioIdentity.IdUsuario
                && x.EmpresaId == _usuarioIdentity.IdEmpresa
                && x.Excluir == true);
            }
            return permissao;
        }

        private void Validar(Permissao model)
        {
            var validacao = new PermissaoValidacao(model);

            if (validacao.Contract.Notifications.Count() > 0)
            {
                foreach (var notificacao in validacao.Contract.Notifications)
                    _notificacao.Adicionar(notificacao.Message);
            }
        }

        public void Salvar(Permissao model)
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

        public void Relatorio(int empresaId, int usuarioId)
        {
            PermissaoAcao(_usuarioIdentity.IdEmpresa, _usuarioIdentity.IdUsuario, EnPermissao.Relatorio);
        }

        public INotificacao Notificacao()
        {
            return _notificacao;
        }
    }
}
