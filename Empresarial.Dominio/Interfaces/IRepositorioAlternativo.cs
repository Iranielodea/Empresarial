using System;
using System.Collections.Generic;
using System.Text;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioAlternativo<T> where T : class
    {
        IEnumerable<T> RetornarLista(string instrucaoSQL);
    }
}
