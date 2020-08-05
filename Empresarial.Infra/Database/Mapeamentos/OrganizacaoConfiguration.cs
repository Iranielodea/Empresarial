using Empresarial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class OrganizacaoConfiguration : EntidadeBasicaConfiguration<Organizacao>
    {
        public override void Configure(EntityTypeBuilder<Organizacao> builder)
        {
            builder.ToTable("organizacoes");
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);

            builder.HasIndex(x => x.Nome).IsUnique();
        }
    }
}
