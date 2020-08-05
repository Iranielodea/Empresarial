using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Empresarial.Dominio.Interfaces.Servicos;
using Empresarial.Dominio.Servicos;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.Database.RepositorioDapper;
using Empresarial.Infra.Database.RepositoriosEF;
using System;

namespace Empresarial.TesteTela
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var contexto = new Contexto();
            //IRepositorioPaisAlt repAlt = new RepositorioPaisDapper();
            //IRepositorioPais rep = new RepositorioPais(contexto, repAlt);

            var obj = new Teste();
            var pais = new Pais(0,0,"", 333, true);



            string resultado = obj.Retorno(pais);
        }
    }
}
