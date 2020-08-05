using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class UsuarioEmpresaConfiguration : EntidadeBasicaConfiguration<UsuarioEmpresa>
    {
        public override void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.ToTable("UsuariosEmpresas");
            base.Configure(builder);

            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey(x => x.EmpresaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            
        }
    }
}
