using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoUsuario : ServicoBasico
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly IRepositorioUsuarioEmpresa _repositorioUsuarioEmpresa;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario,
            IRepositorioUsuarioEmpresa repositorioUsuarioEmpresa)
        {
            _repositorio = repositorioUsuario;
            _repositorioUsuarioEmpresa = repositorioUsuarioEmpresa;
        }

        public Usuario ObterPorId(int id)
        {
            var model = _repositorio.Find(id);
            if (model == null)
                throw new Exception("Registro não encontrado!");

            return model;
        }

        public IEnumerable<UsuarioConsulta> Filtrar(UsuarioFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public void Excluir(int id)
        {
            var model = _repositorio.Find(id);
            if (model != null)
                _repositorio.Deletar(model);
        }

        public void Salvar(Usuario model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            if (model.Id == 0)
                _repositorio.Insert(model);
            else
                _repositorio.Update(model);
        }

        public Usuario ObterUsuarioSenha(string login, string senha)
        {
            var model = _repositorio.GetAll().FirstOrDefault(x => x.Login == login);
            if (model == null)
                throw new Exception("Usuário não Cadastrado!");

            if (model.Senha != senha)
                throw new Exception("Senha inválida!");

            return model;
        }

        public void SalvarUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa)
        {
            if (usuarioEmpresa.Id == 0)
                _repositorioUsuarioEmpresa.Insert(usuarioEmpresa);
            else
                _repositorioUsuarioEmpresa.Update(usuarioEmpresa);
        }

        public UsuarioEmpresa ObterPorUsuarioEmpresaId(int id)
        {
            return _repositorioUsuarioEmpresa.Find(id);
        }

        public UsuarioEmpresa ObterPorUsuarioId(int usuarioId, int empresaId)
        {
            return _repositorioUsuarioEmpresa.First(x => x.EmpresaId == empresaId && x.UsuarioId == usuarioId);
        }
    }
}
