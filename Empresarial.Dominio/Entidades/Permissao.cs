using FluentValidator.Validation;
using System;

namespace Empresarial.Dominio.Entidades
{
    public class Permissao : EntidadeBase
    {
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public int EmpresaId { get; set; }
        public int ProgramaId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Programa Programa { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

    public class PermissaoValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public PermissaoValidacao(Permissao model)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .HasMinLen(model.EmpresaId.ToString(), 1, "EmpresaId", "Informe a Empresa!");
        }
    }

    public class PermissaoConsulta : EntidadeBase
    {
        public bool Ativo { get; set; }
        public string NomePrograma { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
    }

    public class PermissaoFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }

        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public int ProgramaId { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
