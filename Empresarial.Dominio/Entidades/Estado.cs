namespace Empresarial.Dominio.Entidades
{
    public class Estado : EntidadeBase
    {
        public Estado()
        {
            Ativo = true;
        }
        public string Nome { get; set; }
        public int CodigoIBGE { get; set; }
        public int PaisId { get; set; }
        public bool Ativo { get; set; }
        public string Sigla { get; set; }

        public virtual Pais Pais { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new System.Exception("Nome é Obrigatório!");

            if (string.IsNullOrWhiteSpace(Nome))
                throw new System.Exception("Sigla é Obrigatório!");
        }
    }

    public class EstadoConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
    }

    public class EstadoFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
