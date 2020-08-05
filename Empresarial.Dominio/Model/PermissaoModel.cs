using Empresarial.Dominio.Entidades;

namespace Empresarial.Dominio.Model
{
    public class PermissaoModel : EntidadeBase
    {
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public bool Ativo { get; set; }
        public int EmpresaId { get; set; }
        public int ProgramaId { get; set; }
        public int UsuarioId { get; set; }
        public string NomePrograma { get; set; }
    }

    public class PermissaoConsultaModel : EntidadeBase
    {
        public bool Ativo { get; set; }
        public string NomePrograma { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
    }
}
