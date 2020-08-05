using Empresarial.Dominio.Entidades;

namespace Empresarial.Dominio.Model
{
    public class EmpresaModel : EntidadeBase
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscEstadual { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string InscMunicipal { get; set; }
        public string CNAE { get; set; }
        public string CRT { get; set; }
        public string Fone { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public int OrganizacaoId { get; set; }
        public string NomeOrganizacao { get; set; }
    }
}
