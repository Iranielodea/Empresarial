using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.RepositoriosEF;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Infra.Database.RepositoriosEF
{
    public class RepositorioPermissao : RepositorioBase<Permissao>, IRepositorioPermissao
    {
        Contexto _contexto;
        readonly IRepositorioPermissaoAlt _repositorioAlt;

        public RepositorioPermissao(Contexto contexto, IRepositorioPermissaoAlt repositorioAlt) 
            : base(contexto)
        {
            _contexto = contexto;
            _repositorioAlt = repositorioAlt;
        }

        public IEnumerable<PermissaoConsulta> Filtrar(PermissaoFiltro filtro)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" SELECT ID, NOME, ATIVO FROM permissoes p ");
            sb.AppendLine(" INNER JOIN usuarios u ON p.UsuarioId = u.Id");
            sb.AppendLine(" INNER JOIN empresas e ON p.EmpresaId = e.Id");
            sb.AppendLine(" INNER JOIN programas r ON p.ProgramaId = r.Id");

            sb.AppendLine(" WHERE " + filtro.Campo + " like '%" + filtro.Valor + "%'");
            if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
            {
                if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
                    sb.AppendLine(" AND p.ATIVO = 1");
                else
                    sb.AppendLine(" AND p.ATIVO = 0");
            }

            return _repositorioAlt.RetornarTodos(sb.ToString());
        }

        //public IEnumerable<PermissaoConsulta> Filtrar(PermissaoFiltro filtro)
        //{
        //    var resultado = from p in _contexto.Permissoes
        //                    join u in _contexto.Usuarios on p.UsuarioId equals u.Id
        //                    join e in _contexto.Empresas on p.EmpresaId equals e.Id
        //                    join r in _contexto.Programas on p.ProgramaId equals r.Id
        //                    select new
        //                    {
        //                        id = p.Id,
        //                        nomePrograma = r.Nome,
        //                        //ativo = p.Ativo,
        //                        empresaId = p.EmpresaId,
        //                        usuarioId = p.UsuarioId,
        //                        programaId = p.ProgramaId,
        //                        PermissaoAcesso = p.Acesso,
        //                        PermissaoIncluir = p.Incluir,
        //                        PermissaoEditar = p.Editar,
        //                        PermissaoExcluir = p.Excluir,
        //                        PermissaoRelatorio = p.Relatorio
        //                    };
        //    resultado = resultado.Where(x => x.id > 0);

        //    if (filtro.EmpresaId > 0)
        //        resultado = resultado.Where(x => x.empresaId == filtro.EmpresaId);
        //    if (filtro.UsuarioId > 0)
        //        resultado = resultado.Where(x => x.usuarioId == filtro.UsuarioId);
        //    if (filtro.ProgramaId > 0)
        //        resultado = resultado.Where(x => x.programaId == filtro.ProgramaId);

        //    //if (filtro.Ativo != Dominio.Enums.EnSimNao.Todos)
        //    //{
        //    //    if (filtro.Ativo == Dominio.Enums.EnSimNao.Sim)
        //    //        resultado = resultado.Where(x => x.ativo == true);
        //    //    else
        //    //        resultado = resultado.Where(x => x.ativo == false);
        //    //}

        //    //var lista = new List<PermissaoConsulta>();

        //    //foreach (var item in resultado)
        //    //{
        //    //    lista.Add(new PermissaoConsulta()
        //    //    {
        //    //        Id = item.id,
        //    //        NomePrograma = item.nomePrograma,
        //    //        Acesso = item.PermissaoAcesso,
        //    //        Editar = item.PermissaoEditar,
        //    //        Excluir = item.PermissaoExcluir,
        //    //        Incluir = item.PermissaoIncluir,
        //    //        Relatorio = item.PermissaoRelatorio
        //    //    });
        //    //}

        //    //return lista;
        //    return (IEnumerable<PermissaoConsulta>)resultado;
        //}
    }
}
