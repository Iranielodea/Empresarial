using Empresarial.Dominio.ValueObject;

namespace Empresarial.Dominio.Entidades
{
    public class Empresa : EntidadeBase
    {
        public Empresa()
        {
            Ativo = true;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscEstadual { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string InscMunicipal { get; set; }
        public string CNAE { get; set; }
        public int CRT { get; set; }
        public string Fone { get; set; }
        public bool Ativo { get; set; }
        //public string Email { get; set; }
        public int OrganizacaoId { get; set; }

        public virtual Organizacao Organizacao { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new System.Exception("Nome é Obrigatório!");
            }
        }
    }

    public class EmpresaConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

    public class EmpresaFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public int OrganizacaoId { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
