﻿// <auto-generated />
using System;
using FinancialDocument.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancialDocument.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211209001312_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseGuidCollation("")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("FinancialDocument.Core.Entities.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier(36)");

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
                            Id = new Guid("81c4b2b8-c81a-4023-8891-0c4ff2fff018"),
                            Active = 1ul,
                            Description = "Dinheiro",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("37a75580-693b-49da-ba5e-da5b969bab07"),
                            Active = 1ul,
                            Description = "Boleto banco nacional",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("04a9912d-0b15-4765-8688-9196a15516fa"),
                            Active = 1ul,
                            Description = "Boleto banco estadual",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("af7dc8db-fc94-4051-a36b-0a1bfc413c0b"),
                            Active = 1ul,
                            Description = "Cartão de crédito à vista",
                            Installments = 1
                        },
                        new
                        {
                            Id = new Guid("619b9c52-e598-4741-ba0d-51dd5c908396"),
                            Active = 1ul,
                            Description = "Cartão de crédito 3 vezes",
                            Installments = 3
                        });
                });

            modelBuilder.Entity("FinancialDocument.Core.Entities.ReceivingLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier(36)");

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
                            Id = new Guid("93f699b6-6ac5-431c-a489-2a9d5df329f1"),
                            Active = 1ul,
                            Description = "Caixa interno"
                        },
                        new
                        {
                            Id = new Guid("53b870aa-387f-46ff-a36b-0467f7321b71"),
                            Active = 1ul,
                            Description = "Conta banco nacional"
                        },
                        new
                        {
                            Id = new Guid("4beb2639-9b6e-4f1e-8d21-73933fc5be80"),
                            Active = 1ul,
                            Description = "Conta banco estadual"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
