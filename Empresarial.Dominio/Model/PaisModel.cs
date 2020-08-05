using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.ValueObject;

namespace Empresarial.Dominio.Model
{
    public class PaisModel : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public IBGE BACEN { get; set; }
        public bool Ativo { get; set; }
    }

    public class PaisConsultaModel : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
