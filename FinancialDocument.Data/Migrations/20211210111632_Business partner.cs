using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDocument.Data.Migrations
{
    public partial class Businesspartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("04a9912d-0b15-4765-8688-9196a15516fa"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("37a75580-693b-49da-ba5e-da5b969bab07"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("619b9c52-e598-4741-ba0d-51dd5c908396"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("81c4b2b8-c81a-4023-8891-0c4ff2fff018"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("af7dc8db-fc94-4051-a36b-0a1bfc413c0b"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("4beb2639-9b6e-4f1e-8d21-73933fc5be80"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("53b870aa-387f-46ff-a36b-0467f7321b71"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("93f699b6-6ac5-431c-a489-2a9d5df329f1"));

            migrationBuilder.CreateTable(
                name: "BusinessPartner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TradingName = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorporateName = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celphone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<ulong>(type: "bit", nullable: true, defaultValue: 1ul),
                    IsSupplier = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 0ul),
                    IsCustomer = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 0ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartner", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsCustomer", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("b52cbcd1-e074-4643-988c-c96cf7ede829"), 1ul, "NYC", "", "National cutomer", 1ul, null, "985555-5555", "National cutomer" });

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsSupplier", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("088c2d77-d46a-4859-933c-4a00ee75ef49"), 1ul, "LA", "", "National supplier", 1ul, null, "975555-5555", "National supplier" });

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsCustomer", "IsSupplier", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("dfce158b-239a-40f0-a329-ad52c9cd2d22"), 1ul, "WD", "", "Logistic partner", 1ul, 1ul, null, "965555-5555", "Logistic partner" });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Active", "Description", "Installments", "Observation" },
                values: new object[,]
                {
                    { new Guid("0ab926e2-756f-4bb9-87a9-f4cecaca454e"), 1ul, "Dinheiro", 1, null },
                    { new Guid("18e3b921-ef77-4400-a73e-ccaa10f4a359"), 1ul, "Boleto banco nacional", 1, null },
                    { new Guid("e8fefab2-46a6-42a1-86c0-c5aba26f6097"), 1ul, "Boleto banco estadual", 1, null },
                    { new Guid("87acf46b-77c0-494c-bbdd-3fd5898ab265"), 1ul, "Cartão de crédito à vista", 1, null },
                    { new Guid("314aa597-82db-4d18-a612-2e8f4bb8042c"), 1ul, "Cartão de crédito 3 vezes", 3, null }
                });

            migrationBuilder.InsertData(
                table: "ReceivingLocation",
                columns: new[] { "Id", "Active", "Description", "Observation" },
                values: new object[,]
                {
                    { new Guid("126ead04-b4f2-46aa-b16d-a220103a9a93"), 1ul, "Caixa interno", null },
                    { new Guid("ec8c936d-412e-4d6c-b8f8-4e6ae7831ff1"), 1ul, "Conta banco nacional", null },
                    { new Guid("58d61271-f3fb-4e84-a389-52bf62451f0f"), 1ul, "Conta banco estadual", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPartner");

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("0ab926e2-756f-4bb9-87a9-f4cecaca454e"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("18e3b921-ef77-4400-a73e-ccaa10f4a359"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("314aa597-82db-4d18-a612-2e8f4bb8042c"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("87acf46b-77c0-494c-bbdd-3fd5898ab265"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("e8fefab2-46a6-42a1-86c0-c5aba26f6097"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("126ead04-b4f2-46aa-b16d-a220103a9a93"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("58d61271-f3fb-4e84-a389-52bf62451f0f"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("ec8c936d-412e-4d6c-b8f8-4e6ae7831ff1"));

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
    }
}
