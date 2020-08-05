using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Empresarial.Infra.Database.RepositorioDapper
{
    public class RepositorioPermissaoDapper : RepositorioDapper<PermissaoConsulta>, IRepositorioPermissaoAlt
    {
        public RepositorioPermissaoDapper(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<PermissaoConsulta> RetornarTodos(String instrucaoSQL)
        {
            return RetornarLista(instrucaoSQL);
        }
    }
}
