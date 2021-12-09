using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDocument.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<ulong>(type: "bit", nullable: true, defaultValue: 1ul),
                    Installments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReceivingLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Description = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<ulong>(type: "bit", nullable: true, defaultValue: 1ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingLocation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Active", "Description", "Installments", "Observation" },
                values: new object[,]
                {
                    { new Guid("81c4b2b8-c81a-4023-8891-0c4ff2fff018"), 1ul, "Dinheiro", 1, null },
                    { new Guid("37a75580-693b-49da-ba5e-da5b969bab07"), 1ul, "Boleto banco nacional", 1, null },
                    { new Guid("04a9912d-0b15-4765-8688-9196a15516fa"), 1ul, "Boleto banco estadual", 1, null },
                    { new Guid("af7dc8db-fc94-4051-a36b-0a1bfc413c0b"), 1ul, "Cartão de crédito à vista", 1, null },
                    { new Guid("619b9c52-e598-4741-ba0d-51dd5c908396"), 1ul, "Cartão de crédito 3 vezes", 3, null }
                });

            migrationBuilder.InsertData(
                table: "ReceivingLocation",
                columns: new[] { "Id", "Active", "Description", "Observation" },
                values: new object[,]
                {
                    { new Guid("93f699b6-6ac5-431c-a489-2a9d5df329f1"), 1ul, "Caixa interno", null },
                    { new Guid("53b870aa-387f-46ff-a36b-0467f7321b71"), 1ul, "Conta banco nacional", null },
                    { new Guid("4beb2639-9b6e-4f1e-8d21-73933fc5be80"), 1ul, "Conta banco estadual", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "ReceivingLocation");
        }
    }
}
