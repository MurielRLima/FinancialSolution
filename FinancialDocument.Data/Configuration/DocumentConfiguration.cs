using FinancialDocument.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialDocument.Data.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("UniqueIdentifier")
                .ValueGeneratedNever();

            builder.ToTable("Document");

            builder.Property(t => t.DocumentNumber)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

            builder.Property(t => t.BusinessPartnerId)
                .IsRequired()
                .HasColumnType("char(36)");

            builder.Property(t => t.DocumentType)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.Property(t => t.IssueDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.DueDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnType("decimal(15,2)");

            builder.Property(t => t.PaymentMethodId)
                .IsRequired()
                .HasColumnType("char(36)");

            builder.Property(t => t.ReceivingLocationId)
                .IsRequired()
                .HasColumnType("char(36)");

            builder.Property(t => t.Observation)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Settled)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("bit");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");

            // Relationships
            builder.HasOne(t => t.businessPartner)
                .WithMany(t => t.Documents)
                .HasForeignKey(t => t.BusinessPartnerId);

            builder.HasOne(t => t.paymentMethod)
                .WithMany(t => t.Documents)
                .HasForeignKey(t => t.PaymentMethodId);

            builder.HasOne(t => t.receivinglocation)
                .WithMany(t => t.Documents)
                .HasForeignKey(t => t.ReceivingLocationId);
        }
    }
}