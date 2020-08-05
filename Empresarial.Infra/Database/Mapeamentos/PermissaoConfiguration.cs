using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class PermissaoConfiguration : EntidadeBasicaConfiguration<Permissao>
    {
        public override void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissoes");
            base.Configure(builder);

            builder.HasOne(x => x.Empresa).WithMany().HasForeignKey(x => x.EmpresaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(x => x.Programa).WithMany(x => x.Permissoes).HasForeignKey(x => x.ProgramaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(x => x.Usuario).WithMany(x => x.Permissoes).HasForeignKey(x => x.UsuarioId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}
