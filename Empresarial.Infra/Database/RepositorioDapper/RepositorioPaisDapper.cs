using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Empresarial.Infra.Database.RepositorioDapper
{
    public class RepositorioPaisDapper : RepositorioDapper<PaisConsulta>, IRepositorioPaisAlt
    {
        public RepositorioPaisDapper(IConfiguration config) :base(config)
        {
        }

        public IEnumerable<PaisConsulta> RetornarTodos(String instrucaoSQL)
        {
            return RetornarLista(instrucaoSQL);
        }
    }
}
