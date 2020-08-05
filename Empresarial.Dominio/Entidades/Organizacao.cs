namespace Empresarial.Dominio.Entidades
{
    public class Organizacao : EntidadeBase
    {
        public Organizacao()
        {
            Ativo = true;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new System.Exception("Nome é Obrigatório!");
        }
    }

    public class OrganizacaoConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

    public class OrganizacaoFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
