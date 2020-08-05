using Empresarial.Dominio.Entidades;

namespace Empresarial.Dominio.Model
{
    public class ProgramaModel : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
