using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using System.Linq;

namespace Empresarial.Dominio.Servicos
{
    public class ServicoUsuarioEmpresa : ServicoBasico
    {
        private readonly IRepositorioUsuarioEmpresa _repositorio;

        public ServicoUsuarioEmpresa(IRepositorioUsuarioEmpresa repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioEmpresa ObterPorId(int id)
        {
            return _repositorio.Find(id);
        }

        public void Excluir(int id)
        {
            var model = _repositorio.Find(id);
            if (model != null)
                _repositorio.Deletar(model);
        }

        public void Salvar(UsuarioEmpresa model)
        {
            var usuario = _repositorio.GetAll()
                .FirstOrDefault(x => x.Id != model.Id && x.Padrao == true);

            if (model.Padrao == true && usuario != null)
            {
                usuario.Padrao = false;
                _repositorio.Update(usuario);
            }

            if (model.Padrao == false && usuario == null)
            {
                throw new System.Exception("Marque uma Empresa como Padrão!");
            }

            if (model.Id == 0)
                _repositorio.Insert(model);
            else
                _repositorio.Update(model);
        }

        public UsuarioEmpresa ObterPorUsuarioId(int empresaId, int usuarioId)
        {
            return _repositorio.First(x => x.EmpresaId == empresaId && x.UsuarioId == usuarioId);
        }
    }
}
