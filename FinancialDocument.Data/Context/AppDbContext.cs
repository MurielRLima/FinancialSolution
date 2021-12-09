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
            #endregion
        }

        #region DbSets
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ReceivingLocation> ReceivingLocations { get; set; }
        #endregion

    }
}
