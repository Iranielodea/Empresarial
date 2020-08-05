using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class CidadeConfiguration : EntidadeBasicaConfiguration<Cidade>
    {
        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidades");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
            builder.Property(x => x.CEP).HasMaxLength(10);

            builder.HasIndex(x => x.Nome).IsUnique();
            builder.HasOne(x => x.Estado).WithMany().HasForeignKey(x => x.EstadoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
