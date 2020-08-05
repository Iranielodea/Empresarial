using Empresarial.Dominio.Enums;

namespace Empresarial.Dominio.Entidades
{
    public class Cidade : EntidadeBase
    {
        public Cidade()
        {
            Ativo = true;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int CodigoIBGE { get; set; }
        public string CEP { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new System.Exception("Informe o Nome!");
        }
    }

    public class CidadeConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
    }

    public class CidadeFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
