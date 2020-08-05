using Empresarial.Aplicacao;
using Empresarial.Aplicacao.Concretas;
using Empresarial.Aplicacao.Interfaces;
using Empresarial.Dominio.Interfaces;
using Empresarial.Dominio.Interfaces.RepositorioAlternativo;
using Empresarial.Dominio.Interfaces.Servicos;
using Empresarial.Dominio.Servicos;
using Empresarial.Dominio.Shared;
using Empresarial.Infra.Database.ContextoPrincipal;
using Empresarial.Infra.Database.RepositorioDapper;
using Empresarial.Infra.Database.RepositoriosEF;
using Empresarial.Servico.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Empresarial.Cross.IOC
{
    public static class IOCManager
    {
        public static void Register(string connectionString, IServiceCollection services)
        {
            //services.AddDbContext<Contexto>(options =>
            //    options.UseMySql(connectionString).UseLazyLoadingProxies());

            services.AddDbContext<Contexto>(options =>
                options.UseMySql(connectionString));

            //services.AddDbContext<ContextoPrincipal>(options => options.UseSqlServer(connectionString).UseLazyLoadingProxies());
            services.AddScoped<ITransacao, Transacao>();

            var coreAssembly = System.Reflection.Assembly.GetAssembly(typeof(ServicoBasico));
            var infraAssembly = System.Reflection.Assembly.GetAssembly(typeof(RepositorioPais));

            services.AddScoped<IRepositorioPais, RepositorioPais>();
            services.AddScoped<IRepositorioPrograma, RepositorioPrograma>();
            services.AddScoped<IRepositorioOrganizacao, RepositorioOrganizacao>();
            services.AddScoped<IRepositorioEstado, RepositorioEstado>();
            services.AddScoped<IRepositorioCidade, RepositorioCidade>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
            services.AddScoped<IRepositorioPermissao, RepositorioPermissao>();
            services.AddScoped<IRepositorioUsuarioEmpresa, RepositorioUsuarioEmpresa>();
            //=================================================================
            // REPOSITORIO DAPPER
            //=================================================================

            services.AddScoped(typeof(IRepositorioAlternativo<>), typeof(RepositorioDapper<>));
            services.AddScoped<IRepositorioPaisAlt, RepositorioPaisDapper>();
            services.AddScoped<IRepositorioPermissaoAlt, RepositorioPermissaoDapper>();
            //=================================================================
            // SERVICOS
            //=================================================================
            services.AddScoped(typeof(IServicoBase<>), typeof(Dominio.Servicos.ServicoBase<>));
            services.AddScoped<IServicoPais, ServicoPais>();
            services.AddScoped<IServicoPermissao, ServicoPermissao>();
            services.AddScoped<IServicoPrograma, ServicoPrograma>();
            services.AddScoped<IServicoCidade, ServicoCidade>();
            services.AddScoped<IServicoEstado, ServicoEstado>();
            services.AddScoped<IServicoOrganizacao, ServicoOrganizacao>();
            services.AddScoped<IServicoEmpresa, ServicoEmpresa>();
            services.AddScoped<INotificacao, Notificacao>();

            //=================================================================
            // APLICACAO
            //=================================================================
            services.AddScoped(typeof(IAppServicoBase<>), typeof(AppServicoBase<>));
            services.AddScoped<IAppServicoPais, AppServicoPais>();
            services.AddScoped<IAppServicoPermissao, AppServicoPermissao>();

            

            var classesServico = coreAssembly
                    .GetTypes()
                    .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(ServicoBasico)))
                    .ToArray();
            foreach (var c in classesServico)
                services.AddScoped(c);
        }
    }
}
