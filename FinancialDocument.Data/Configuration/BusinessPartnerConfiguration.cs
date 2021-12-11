using FinancialDocument.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialDocument.Data.Configuration
{
    public class BusinessPartnerConfiguration : IEntityTypeConfiguration<BusinessPartner>
    {
        public void Configure(EntityTypeBuilder<BusinessPartner> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("UniqueIdentifier")
                .ValueGeneratedNever();

            builder.ToTable("BusinessPartner");

            builder.Property(t => t.TradingName)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(t => t.CorporateName)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(t => t.Address)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(t => t.Telephone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(t => t.Celphone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(t => t.Observation)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Active)
                .IsRequired(false)
                .HasDefaultValue(true)
                .HasColumnType("bit");

            builder.Property(t => t.IsSupplier)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("bit");

            builder.Property(t => t.IsCustomer)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("bit");

            // Relationships
            //builder.HasOne(t => t.EmpresaMatriz)
            //    .WithMany(t => t.MatrizContratos)
            //    .HasForeignKey(t => t.EmpresaMatrizId);
        }
    }
}
