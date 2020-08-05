using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class ProgramaConfiguration : EntidadeBasicaConfiguration<Programa>
    {
        public override void Configure(EntityTypeBuilder<Programa> builder)
        {
            builder.ToTable("programas");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);

            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}
