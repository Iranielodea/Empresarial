using System.Collections.Generic;

namespace Empresarial.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Usuario()
        {
            Ativo = true;
        }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Permissao> Permissoes { get; set; }
        //public virtual ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; }
    }

    public class UsuarioConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

    public class UsuarioFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
