﻿// <auto-generated />
using System;
using FinancialDocument.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDocument.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211210111632_Business partner")]
    partial class Businesspartner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseGuidCollation("")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("FinancialDocument.Core.Entities.BusinessPartner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<ulong?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(1ul);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Celphone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<ulong>("IsCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(0ul);

                    b.Property<ulong>("IsSupplier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(0ul);

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TradingName")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("BusinessPartner");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b52cbcd1-e074-4643-988c-c96cf7ede829"),
                            Active = 1ul,
                            Address = "NYC",
                            Celphone = "",
                            CorporateName = "National cutomer",
                            IsCustomer = 1ul,
                            IsSupplier = 0ul,
                            Telephone = "985555-5555",
                            TradingName = "National cutomer"
                        },
                        new
                        {
                            Id = new Guid("088c2d77-d46a-4859-933c-4a00ee75ef49"),
                            Active = 1ul,
                            Address = "LA",
                            Celphone = "",
                            CorporateName = "National supplier",
                            IsCustomer = 0ul,
                            IsSupplier = 1ul,
                            Telephone = "975555-5555",
                            TradingName = "National supplier"
                        },
                        new
                        {
                            Id = new Guid("dfce158b-239a-40f0-a329-ad52c9cd2d22"),
                            Active = 1ul,
                            Address = "WD",
                            Celphone = "",
                            CorporateName = "Logistic partner",
                            IsCustomer = 1ul,
                            IsSupplier = 1ul,
                            Telephone = "965555-5555",
                            TradingName = "Logistic partner"
                        });
                });

            modelBuilder.Entity("FinancialDocument.Core.Entities.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<ulong?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(1ul);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ab926e2-756f-4bb9-87a9-f4cecaca454e"),
                            Active = 1ul,
                            Description = "Dinheiro",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("18e3b921-ef77-4400-a73e-ccaa10f4a359"),
                            Active = 1ul,
                            Description = "Boleto banco nacional",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("e8fefab2-46a6-42a1-86c0-c5aba26f6097"),
                            Active = 1ul,
                            Description = "Boleto banco estadual",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("87acf46b-77c0-494c-bbdd-3fd5898ab265"),
                            Active = 1ul,
                            Description = "Cartão de crédito à vista",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("314aa597-82db-4d18-a612-2e8f4bb8042c"),
                            Active = 1ul,
                            Description = "Cartão de crédito 3 vezes",
                            Installments = 3
                        });
                });

            modelBuilder.Entity("FinancialDocument.Core.Entities.ReceivingLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<ulong?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(1ul);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("ReceivingLocation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("126ead04-b4f2-46aa-b16d-a220103a9a93"),
                            Active = 1ul,
                            Description = "Caixa interno"
                        },
                        new
                        {
                            Id = new Guid("ec8c936d-412e-4d6c-b8f8-4e6ae7831ff1"),
                            Active = 1ul,
                            Description = "Conta banco nacional"
                        },
                        new
                        {
                            Id = new Guid("58d61271-f3fb-4e84-a389-52bf62451f0f"),
                            Active = 1ul,
                            Description = "Conta banco estadual"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
