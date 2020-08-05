using Empresarial.Dominio.ValueObject;
using FluentValidator.Validation;

namespace Empresarial.Dominio.Entidades
{
    public class Pais : EntidadeBase
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public IBGE BACEN { get; private set; }
        public bool Ativo { get; private set; }

        public Pais(int id, int codigo, string nome, int bacen, bool ativo)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            BACEN = new IBGE(bacen);
            Ativo = ativo;
        }

        protected Pais() { }
    }

    public class PaisValidacao : IContract
    {
        public ValidationContract Contract { get; }

        public PaisValidacao(Pais model)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNullOrEmpty(model.Nome, "Nome", "Informe o Nome do País!");
        }
    }

    public class PaisConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

    public class PaisFiltro
    {
        public int Id { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
