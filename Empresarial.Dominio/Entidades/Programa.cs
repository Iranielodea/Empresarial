using System;
using System.Collections.Generic;

namespace Empresarial.Dominio.Entidades
{
    public class Programa : EntidadeBase
    {
        public Programa()
        {
            Ativo = true;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("Informe o Nome!");
        }
    }

    public class ProgramaConsulta : EntidadeBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

    public class ProgramaFiltro
    {
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public Enums.EnSimNao Ativo { get; set; }
    }
}
