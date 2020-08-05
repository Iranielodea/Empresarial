using Empresarial.Dominio.Entidades;

namespace Empresarial.Dominio.Model
{
    public class CidadeModel : EntidadeBase
    {
        public CidadeModel()
        {
            Ativo = true;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int CodigoIBGE { get; set; }
        public string CEP { get; set; }
        public int EstadoId { get; set; }
        public string Sigla { get; set; }
        public string NomeEstado { get; set; }
    }
}
