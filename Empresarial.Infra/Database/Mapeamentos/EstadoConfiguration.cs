using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class EstadoConfiguration : EntidadeBasicaConfiguration<Estado>
    {
        public override void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estados");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Sigla).IsRequired().HasMaxLength(2);

            builder.HasIndex(x => x.Nome).IsUnique();
            builder.HasIndex(x => x.Sigla).IsUnique();
            builder.HasOne(x => x.Pais).WithMany().HasForeignKey(x => x.PaisId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}
