using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoBancoDados
    {
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioEstado _repositorioEstado;
        private readonly IRepositorioCidade _repositorioCidade;
        private readonly IRepositorioOrganizacao _repositorioOrganizacao;
        private readonly IRepositorioEmpresa _repositorioEmpresa;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioPermissao _repositorioPermissao;
        private readonly IRepositorioPrograma _repositorioPrograma;
        private readonly IRepositorioUsuarioEmpresa _repositorioUsuarioEmpresa;

        public ServicoBancoDados(IRepositorioPais repositorioPais, IRepositorioEstado repositorioEstado,
            IRepositorioCidade repositorioCidade, IRepositorioOrganizacao repositorioOrganizacao,
            IRepositorioEmpresa repositorioEmpresa, IRepositorioUsuario repositorioUsuario,
            IRepositorioPermissao repositorioPermissao, IRepositorioPrograma repositorioPrograma,
            IRepositorioUsuarioEmpresa repositorioUsuarioEmpresa)
        {
            _repositorioPais = repositorioPais;
            _repositorioEstado = repositorioEstado;
            _repositorioCidade = repositorioCidade;
            _repositorioOrganizacao = repositorioOrganizacao;
            _repositorioEmpresa = repositorioEmpresa;
            _repositorioUsuario = repositorioUsuario;
            _repositorioPermissao = repositorioPermissao;
            _repositorioPrograma = repositorioPrograma;
            _repositorioUsuarioEmpresa = repositorioUsuarioEmpresa;
        }

        public void GravarInicio()
        {
            GravarProgramas();
            GravarPais();
            GravarEstado();
            GravarCidade();
            GravarOrganizacao();
            GravarEmpresa();
            GravarUsuario();
            GravarPermissao();
            //GravarUsuarioPermissao();
        }

        private Pais GravarPais()
        {
            var model = _repositorioPais.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Pais(0, 0, "IRANI", 11, true);
                _repositorioPais.Insert(model);
            }
            else
                _repositorioPais.Update(model);

            return model;
        }

        private Estado GravarEstado()
        {
            var model = _repositorioEstado.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Estado();
                model.Nome = "Rio Grande do Sul";
                model.Pais = GravarPais();
                model.Sigla = "RS";
                _repositorioEstado.Insert(model);
            }
            else
                _repositorioEstado.Update(model);

            return model;
        }

        private void GravarCidade()
        {
            var model = _repositorioCidade.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Cidade();
                model.Nome = "FLORES DA CUNHA";
                model.CEP = "95270000";
                model.CodigoIBGE = 0;
                model.Estado = GravarEstado();
                _repositorioCidade.Insert(model);
            }
            else
                _repositorioCidade.Update(model);
        }

        private Organizacao GravarOrganizacao()
        {
            var model = _repositorioOrganizacao.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Organizacao();
                model.Nome = "Organizacao";
                _repositorioOrganizacao.Insert(model);
            }
            else
                _repositorioOrganizacao.Update(model);

            return model;
        }

        private Empresa GravarEmpresa()
        {
            var model = _repositorioEmpresa.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Empresa();
                model.Nome = "Empresa1";
                model.Organizacao = GravarOrganizacao();
                _repositorioEmpresa.Insert(model);
            }
            else
                _repositorioEmpresa.Update(model);

            return model;
        }

        private Usuario GravarUsuario()
        {
            var model = _repositorioUsuario.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Usuario();
                model.Nome = "Usuario1";
                model.Login = "usuario";
                model.Senha = "11";
                _repositorioUsuario.Insert(model);
            }
            else
                _repositorioUsuario.Update(model);

            return model;
        }

        private UsuarioEmpresa GravarUsuarioEmpresa()
        {
            var model = _repositorioUsuarioEmpresa.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new UsuarioEmpresa();
                model.Empresa = GravarEmpresa();
                model.Usuario = GravarUsuario();
                //model.Ativo = true;
                _repositorioUsuarioEmpresa.Insert(model);
            }
            else
                _repositorioUsuarioEmpresa.Update(model);

            return model;
        }

        private Permissao GravarPermissao()
        {
            var model = _repositorioPermissao.GetAll().FirstOrDefault(x => x.Id > 0);
            if (model == null)
            {
                model = new Permissao();
                model.Empresa = GravarEmpresa();
                model.Programa = _repositorioPrograma.First(x => x.Id > 0);
                model.Usuario = GravarUsuario();
                _repositorioPermissao.Insert(model);
            }
            else
                _repositorioPermissao.Update(model);

            return model;
        }

        private void GravarProgramas()
        {
            var listaBanco = _repositorioPrograma.GetAll().ToList();

            var listaProgramas = ListarProgramas();
            foreach (var item in listaProgramas)
            {
                if (!listaBanco.Any(x => x.Codigo == item.Codigo))
                {
                    _repositorioPrograma.Insert(item);
                }
            }
        }

        private List<Programa> ListarProgramas()
        {
            var lista = new List<Programa>();

            lista.Add(new Programa() { Codigo = 1, Nome = "Países", Ativo = true });
            lista.Add(new Programa() { Codigo = 2, Nome = "Programas", Ativo = true });
            lista.Add(new Programa() { Codigo = 3, Nome = "Permissões", Ativo = true });
            lista.Add(new Programa() { Codigo = 4, Nome = "Cidades", Ativo = true });
            lista.Add(new Programa() { Codigo = 5, Nome = "Empresas", Ativo = true });
            lista.Add(new Programa() { Codigo = 6, Nome = "Estados", Ativo = true });
            lista.Add(new Programa() { Codigo = 7, Nome = "Organizações", Ativo = true });
            lista.Add(new Programa() { Codigo = 8, Nome = "Parametros", Ativo = true });
            lista.Add(new Programa() { Codigo = 9, Nome = "Usuários", Ativo = true });

            return lista;
        }
    }
}
