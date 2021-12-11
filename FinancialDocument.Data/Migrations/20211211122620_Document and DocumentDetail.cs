using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialDocument.Data.Migrations
{
    public partial class DocumentandDocumentDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("088c2d77-d46a-4859-933c-4a00ee75ef49"));

            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("b52cbcd1-e074-4643-988c-c96cf7ede829"));

            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("dfce158b-239a-40f0-a329-ad52c9cd2d22"));

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

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BusinessPartnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DocumentType = table.Column<string>(type: "char(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<double>(type: "decimal(15,2)", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ReceivingLocationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Settled = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 0ul),
                    Active = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 1ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_BusinessPartner_BusinessPartnerId",
                        column: x => x.BusinessPartnerId,
                        principalTable: "BusinessPartner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_ReceivingLocation_ReceivingLocationId",
                        column: x => x.ReceivingLocationId,
                        principalTable: "ReceivingLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DocumentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OperationType = table.Column<string>(type: "char(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<double>(type: "decimal(15,2)", nullable: false),
                    Observation = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<ulong>(type: "bit", nullable: false, defaultValue: 1ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDetail_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsCustomer", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("42813041-f6e0-49e3-93b7-4d1400b0c7b6"), 1ul, "NYC", "", "National cutomer", 1ul, null, "985555-5555", "National cutomer" });

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsSupplier", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("6d357424-cf26-4efc-8723-b92c4ed4ca1b"), 1ul, "LA", "", "National supplier", 1ul, null, "975555-5555", "National supplier" });

            migrationBuilder.InsertData(
                table: "BusinessPartner",
                columns: new[] { "Id", "Active", "Address", "Celphone", "CorporateName", "IsCustomer", "IsSupplier", "Observation", "Telephone", "TradingName" },
                values: new object[] { new Guid("bdad0ecc-949a-48fa-bbc0-9eabbfce4f56"), 1ul, "WD", "", "Logistic partner", 1ul, 1ul, null, "965555-5555", "Logistic partner" });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Active", "Description", "Installments", "Observation" },
                values: new object[,]
                {
                    { new Guid("bc8b0709-b4e9-4f95-9113-ae99b9540e4e"), 1ul, "Dinheiro", 1, null },
                    { new Guid("d997816b-163a-4d98-9194-0603612bcc79"), 1ul, "Boleto banco nacional", 1, null },
                    { new Guid("f66fd18d-899a-4fe2-9fda-247c1a5bfe97"), 1ul, "Boleto banco estadual", 1, null },
                    { new Guid("b5ff2f9b-c4b0-4478-9e50-61dcd37dcb82"), 1ul, "Cartão de crédito à vista", 1, null },
                    { new Guid("d819d8d6-a04a-4ce7-b290-143c79b9d625"), 1ul, "Cartão de crédito 3 vezes", 3, null }
                });

            migrationBuilder.InsertData(
                table: "ReceivingLocation",
                columns: new[] { "Id", "Active", "Description", "Observation" },
                values: new object[,]
                {
                    { new Guid("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"), 1ul, "Caixa interno", null },
                    { new Guid("efa1e8f7-3df9-45a3-855e-a904cd132ce7"), 1ul, "Conta banco nacional", null },
                    { new Guid("373fa65c-4e06-49a2-82fb-bd69c0c7005c"), 1ul, "Conta banco estadual", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_BusinessPartnerId",
                table: "Document",
                column: "BusinessPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PaymentMethodId",
                table: "Document",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ReceivingLocationId",
                table: "Document",
                column: "ReceivingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetail_DocumentId",
                table: "DocumentDetail",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDetail");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("42813041-f6e0-49e3-93b7-4d1400b0c7b6"));

            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("6d357424-cf26-4efc-8723-b92c4ed4ca1b"));

            migrationBuilder.DeleteData(
                table: "BusinessPartner",
                keyColumn: "Id",
                keyValue: new Guid("bdad0ecc-949a-48fa-bbc0-9eabbfce4f56"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("b5ff2f9b-c4b0-4478-9e50-61dcd37dcb82"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("bc8b0709-b4e9-4f95-9113-ae99b9540e4e"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("d819d8d6-a04a-4ce7-b290-143c79b9d625"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("d997816b-163a-4d98-9194-0603612bcc79"));

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: new Guid("f66fd18d-899a-4fe2-9fda-247c1a5bfe97"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("373fa65c-4e06-49a2-82fb-bd69c0c7005c"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("5f5261df-1bb2-4f0b-a901-9cf15dd8ca44"));

            migrationBuilder.DeleteData(
                table: "ReceivingLocation",
                keyColumn: "Id",
                keyValue: new Guid("efa1e8f7-3df9-45a3-855e-a904cd132ce7"));

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
    }
}
