using System;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Dominio.ValueObject
{
    public class CPF
    {
        public const int CPFMaxLength = 15;

        public string Numero {get; private set; }

        public CPF(string cpf)
        {
            Numero = cpf;
        }

        private CPF()
        {
        }
    }
}
