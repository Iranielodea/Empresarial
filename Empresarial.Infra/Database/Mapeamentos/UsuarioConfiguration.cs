using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class UsuarioConfiguration : EntidadeBasicaConfiguration<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(80);

            builder.HasIndex(x => x.Login).IsUnique();
        }
    }
}
