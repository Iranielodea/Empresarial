using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Enums;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace Empresarial.Servico.Servicos
{
    public class ServicoPrograma : ServicoBase<Programa>, IServicoPrograma
    {
        private readonly IRepositorioPrograma _repositorio;
        private readonly IServicoPermissao _servicoPermissao;
        private int _codigoPrograma;

        public ServicoPrograma(IRepositorioPrograma repositorio,
            IServicoPermissao servicoPermissao)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoPermissao = servicoPermissao;
            _codigoPrograma = 2;
        }

        private void PermissaoAcao(int empresaId, int usuarioId, EnPermissao enPermissao)
        {
            bool permissao = _servicoPermissao.Permissao(_codigoPrograma, empresaId, usuarioId, enPermissao);
            if (permissao == false)
                throw new Exception("Usuário sem Permissão!");
        }

        public Programa Editar(int empresaId, int usuarioId, int id)
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

        public IEnumerable<ProgramaConsulta> Filtrar(ProgramaFiltro filtro)
        {
            return _repositorio.Filtrar(filtro);
        }

        public void Novo(int empresaId, int usuarioId)
        {
            PermissaoAcao(empresaId, usuarioId, EnPermissao.Incluir);
        }

        public Programa ObterPorId(int id)
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

        public void Salvar(Programa model)
        {
            model.Validar();

            if (model.Id == 0)
                _repositorio.Insert(model);
            else
                _repositorio.Update(model);
        }
    }
}
