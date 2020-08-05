using System.Collections.Generic;

namespace Empresarial.Dominio.Interfaces
{
    public interface IRepositorioBaseAlt<T> where T : class
    {
        IEnumerable<T> RetornarTodos(string instrucaoSQL);
    }
}
