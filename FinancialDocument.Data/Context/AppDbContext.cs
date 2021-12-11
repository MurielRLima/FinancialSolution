using FinancialDocument.Core.Entities;
using FinancialDocument.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinancialDocument.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var fks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys());

            foreach (var fk in fks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region modelBuilder.ApplyConfiguration
            modelBuilder.UseGuidCollation(string.Empty);
            //
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new ReceivingLocationConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessPartnerConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentDetailConfiguration());
            #endregion

            #region Seed data
            // Payment Method
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = Guid.NewGuid(), Description = "Dinheiro", Installments = 1, Active = true },
                new PaymentMethod { Id = Guid.NewGuid(), Description = "Boleto banco nacional", Installments = 1, Active = true },
                new PaymentMethod { Id = Guid.NewGuid(), Description = "Boleto banco estadual", Installments = 1, Active = true },
                new PaymentMethod { Id = Guid.NewGuid(), Description = "Cartão de crédito à vista", Installments = 1, Active = true },
                new PaymentMethod { Id = Guid.NewGuid(), Description = "Cartão de crédito 3 vezes", Installments = 3, Active = true }
            );
            // Receiving Location
            modelBuilder.Entity<ReceivingLocation>().HasData(
                new ReceivingLocation { Id = Guid.NewGuid(), Description = "Caixa interno", Active = true },
                new ReceivingLocation { Id = Guid.NewGuid(), Description = "Conta banco nacional", Active = true },
                new ReceivingLocation { Id = Guid.NewGuid(), Description = "Conta banco estadual", Active = true }
            );
            // Business Partner
            modelBuilder.Entity<BusinessPartner>().HasData(
                new BusinessPartner { Id = Guid.NewGuid(), TradingName = "National cutomer", CorporateName = "National cutomer", Address = "NYC", Telephone = "985555-5555", Celphone = "", Observation = null, Active = true, IsSupplier = false, IsCustomer = true },
                new BusinessPartner { Id = Guid.NewGuid(), TradingName = "National supplier", CorporateName = "National supplier", Address = "LA", Telephone = "975555-5555", Celphone = "", Observation = null, Active = true, IsSupplier = true, IsCustomer = false },
                new BusinessPartner { Id = Guid.NewGuid(), TradingName = "Logistic partner", CorporateName = "Logistic partner", Address = "WD", Telephone = "965555-5555", Celphone = "", Observation = null, Active = true, IsSupplier = true, IsCustomer = true }
            );
            #endregion
        }

        #region DbSets
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ReceivingLocation> ReceivingLocations { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentDetail> DocumentDetails { get; set; }
        #endregion

    }
}
