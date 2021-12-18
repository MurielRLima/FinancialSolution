using FinancialDocument.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialDocument.Data.Configuration
{
    public class ReceivingLocationConfiguration : IEntityTypeConfiguration<ReceivingLocation>
    {
        public void Configure(EntityTypeBuilder<ReceivingLocation> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("UniqueIdentifier")
                .ValueGeneratedNever();

            builder.ToTable("ReceivingLocation");

            builder.Property(t => t.Description)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(t => t.Observation)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Active)
                .IsRequired(false)
                .HasDefaultValue(true)
                .HasColumnType("bit");

            // Relationships
            //builder.HasOne(t => t.EmpresaMatriz)
            //    .WithMany(t => t.MatrizContratos)
            //    .HasForeignKey(t => t.EmpresaMatrizId);
        }
    }
}
