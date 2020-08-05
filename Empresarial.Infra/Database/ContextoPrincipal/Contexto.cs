using Empresarial.Dominio.Entidades;
using Empresarial.Infra.Database.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Empresarial.Infra.Database.ContextoPrincipal
{
    public class Contexto : DbContext
    {
        /*
         * Instalação do MySql
         * 
         * Pomelo.EntityframeworkCore.MySql
         * Pomelo.EntityframeworkCore.MySql.Design
         * Microsoft.EntityframeworkCore.Tools
         */
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<UsuarioEmpresa> UsuariosEmpresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            //modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            ////modelBuilder.ApplyConfiguration(new EntidadeBasicaConfiguration());
            //modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            //modelBuilder.ApplyConfiguration(new OrganizacaoConfiguration());
            //modelBuilder.ApplyConfiguration(new PaisesConfiguration());
            //modelBuilder.ApplyConfiguration(new PermissaoConfiguration());
            //modelBuilder.ApplyConfiguration(new ProgramaConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioEmpresaConfiguration());



            var tipos = this.GetType().Assembly.GetTypes()
                .Where(x => x.Name.EndsWith("Configuration") &&
                !x.IsAbstract &&
                !x.IsInterface).ToArray();
            foreach (var t in tipos)
            {
                dynamic classe = Activator.CreateInstance(t);
                modelBuilder.ApplyConfiguration(classe);
            }
        }
    }
}
