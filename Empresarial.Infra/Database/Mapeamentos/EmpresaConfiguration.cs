using Empresarial.Dominio.Entidades;
using Empresarial.Dominio.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresarial.Infra.Database.Mapeamentos
{
    public class EmpresaConfiguration : EntidadeBasicaConfiguration<Empresa>
    {
        public override void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresas");
            base.Configure(builder);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Fantasia).HasMaxLength(60);
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(20);
            builder.Property(x => x.InscEstadual).HasMaxLength(25);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(11);
            builder.Property(x => x.InscMunicipal).HasMaxLength(25);
            builder.Property(x => x.CNAE).HasMaxLength(10);
            builder.Property(x => x.CRT).HasMaxLength(11);
            builder.Property(x => x.Fone).HasMaxLength(15);
            //builder.Property(x => x.Email).HasMaxLength(80);
            builder.Property(x => x.CPF).HasMaxLength(15);
            //builder.OwnsOne(x => x.CPF).Property(x => x.Numero).HasColumnName("CPF").HasMaxLength(CPF.CPFMaxLength);

            builder.HasIndex(x => x.Nome).IsUnique();
            builder.HasOne(x => x.Organizacao).WithMany().HasForeignKey(x => x.OrganizacaoId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}
