using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Empresarial.Servico.Servicos
{
    public class ServicoOrganizacao : ServicoBase<Organizacao>, IServicoOrganizacao
    {
        private readonly IRepositorioOrganizacao _repositorio;
        private readonly IServicoPermissao _servicoPermissao;
        private int _codigoOrganizacao;

        public ServicoOrganizacao(IRepositorioOrganizacao repositorio,
            IServicoPermissao servicoPermissao)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoPermissao = servicoPermissao;
            _codigoOrganizacao = 7;
        }

        private void PermissaoAcao(int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = _servicoPermissao.Permissao(_codigoOrganizacao, empresaId, usuarioId, enPermissao);
            if (permissao == false)
                throw new Exception("Usuário sem Permissão!");
        }

        public Organizacao Editar(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Editar);

            return ObterPorId(id);
        }

        public void Excluir(int empresaId, int usuarioId, int id)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Excluir);

            var model = _repositorio.Find(id);
            if (model != null)
            {
                _repositorio.Deletar(model);
            }
        }

        public IEnumerable<OrganizacaoConsulta> Filtrar(OrganizacaoFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public void Novo(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Incluir);
        }

        public Organizacao ObterPorId(int id)
        {
            var model = _repositorio.Find(id);
            if (model == null)
                throw new Exception("Registro não Encontrado!");
            return model;
        }

        public void Relatorio(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Relatorio);
        }

        public void Salvar(Organizacao model)
        {
            model.Validar();

            if (model.Id == 0)
                _repositorio.Insert(model);
            else
                _repositorio.Update(model);
        }
    }
}
