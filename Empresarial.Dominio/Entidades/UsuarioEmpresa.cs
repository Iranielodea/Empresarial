namespace Empresarial.Dominio.Entidades
{
    public class UsuarioEmpresa : EntidadeBase
    {
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public bool Padrao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
