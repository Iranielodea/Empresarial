using System;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Dominio.ValueObject
{
    public class IBGE
    {
        public int Numero { get; private set; }

        protected IBGE() { }

        public IBGE(int numero)
        {
            Numero = numero;
        }

        private void Validar()
        {
            if (Numero <= 0)
                throw new Exception("Informe o Código!");
        }
    }
}
