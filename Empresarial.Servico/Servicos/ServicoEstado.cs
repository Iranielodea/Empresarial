using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Empresarial.Servico.Servicos
{
    public class ServicoEstado : ServicoBase<Estado>, IServicoEstado
    {
        private readonly IRepositorioEstado _repositorio;
        private readonly IServicoPermissao _servicoPermissao;
        private int _codigoEstado;

        public ServicoEstado(IRepositorioEstado repositorio,
            IServicoPermissao servicoPermissao)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoPermissao = servicoPermissao;
            _codigoEstado = 2;
        }

        private void PermissaoAcao(int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = _servicoPermissao.Permissao(_codigoEstado, empresaId, usuarioId, enPermissao);
            if (permissao == false)
                throw new Exception("Usuário sem Permissão!");
        }

        public Estado Editar(int empresaId, int usuarioId, int id)
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

        public IEnumerable<EstadoConsulta> Filtrar(EstadoFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public void Novo(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Incluir);
        }

        public Estado ObterPorId(int id)
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

        public void Salvar(Estado model)
        {
            model.Validar();

            if (model.Id == 0)
                _repositorio.Insert(model);
            else
                _repositorio.Update(model);
        }

        public Estado ObterPorSigla(string sigla)
        {
            var model = _repositorio.First(x => x.Sigla == sigla);
            if (model == null)
                throw new Exception("Registro não Encontrado!");
            return model;
        }
    }
}
