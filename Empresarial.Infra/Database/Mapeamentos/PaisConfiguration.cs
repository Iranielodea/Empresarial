using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class PaisConfiguration : EntidadeBasicaConfiguration<Pais>
    {
        public override void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("paises");
            base.Configure(builder);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);

            builder.OwnsOne(x => x.BACEN, bacen =>
            {
                bacen.Property(x => x.Numero)
                .IsRequired()
                .HasColumnName("BACEN");
            });

            //builder.HasIndex(x => x.BACEN).IsUnique();
            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}
