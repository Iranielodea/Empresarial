using Dapper;
using Empresarial.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Empresarial.Infra.Database.RepositorioDapper
{
    public class RepositorioDapper<T> : IRepositorioAlternativo<T> where T : class
    {
        private readonly IConfiguration _config;

        //string _stringConexao = "Server=localhost;DataBase=erp;Uid=root;Pwd=123456";
        string _stringConexao;

        public RepositorioDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> RetornarLista(string instrucaoSQL)
        {
            //using (var db = new MySqlConnection(_stringConexao))
            //{
            //    return db.Query<T>(instrucaoSQL);
            //}

            _stringConexao = _config.GetSection("ConexaoMySql").GetSection("MySqlConnectionString").Value;
            using (var db = new MySqlConnection(_stringConexao))
            {
                return db.Query<T>(instrucaoSQL);
            }
        }
    }
}
