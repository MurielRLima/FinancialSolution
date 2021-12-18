using FinancialDocument.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDocument.Data.Configuration
{
    public class DocumentDetailConfiguration : IEntityTypeConfiguration<DocumentDetail>
    {
        public void Configure(EntityTypeBuilder<DocumentDetail> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("UniqueIdentifier")
                .ValueGeneratedNever();

            builder.ToTable("DocumentDetail");

            builder.Property(t => t.DocumentId)
                    .IsRequired()
                    .HasColumnType("char(36)");

            builder.Property(t => t.OperationType)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.Property(t => t.Date)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(t => t.Value)
                .IsRequired()
                .HasColumnType("decimal(15,2)");

            builder.Property(t => t.Observation)
                .IsRequired(false)
                .HasColumnType("varchar(1000)");

            builder.Property(t => t.Active)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");

            // Relationships
            builder.HasOne(t => t.document)
                .WithMany(t => t.documentDetails)
                .HasForeignKey(t => t.DocumentId);
        }
    }
}
