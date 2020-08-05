using Empresarial.Dominio.Entidades;

namespace Empresarial.Dominio.Model
{
    public class EstadoModel : EntidadeBase
    {
        public string Nome { get; set; }
        public int CodigoIBGE { get; set; }
        public int PaisId { get; set; }
        public bool Ativo { get; set; }
        public string Sigla { get; set; }
        public string NomePais { get; set; }
    }
}
