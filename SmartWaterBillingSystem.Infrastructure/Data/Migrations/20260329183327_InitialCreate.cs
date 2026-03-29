using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWaterBillingSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "InvoiceNumbersSequence");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    PersonalIDNumber = table.Column<string>(type: "char(10)", nullable: false),
                    SubscriberName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SubscriberGovernorate = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SubscriberArea = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SubscriberPhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SubscriberNote = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.PersonalIDNumber);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfRealEstates",
                columns: table => new
                {
                    HouseType = table.Column<string>(type: "char(1)", nullable: false),
                    TypesName = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    TypesNote = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfRealEstates", x => x.HouseType);
                });

            migrationBuilder.CreateTable(
                name: "SlideDistributions",
                columns: table => new
                {
                    SlideNumber = table.Column<string>(type: "char(1)", nullable: false),
                    SlideDescription = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AmountExpenditureSlide = table.Column<int>(type: "int", nullable: false),
                    PricePerCubicMeterOfWater = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    PriceServiceSewage = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    SlideDistributionNote = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HouseType = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideDistributions", x => x.SlideNumber);
                    table.ForeignKey(
                        name: "FK_SlideDistributions_TypesOfRealEstates_HouseType",
                        column: x => x.HouseType,
                        principalTable: "TypesOfRealEstates",
                        principalColumn: "HouseType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionNumber = table.Column<string>(type: "char(10)", nullable: false),
                    TheNumberOfFloorsOfTheHouse = table.Column<int>(type: "int", nullable: false),
                    IsThereSanitation = table.Column<bool>(type: "bit", nullable: false),
                    TheLastReadingOfTheMeter = table.Column<int>(type: "int", nullable: false),
                    SubscriptionNote = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SubscriberNumber = table.Column<string>(type: "char(10)", nullable: false),
                    HouseType = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionNumber);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Subscribers_SubscriberNumber",
                        column: x => x.SubscriberNumber,
                        principalTable: "Subscribers",
                        principalColumn: "PersonalIDNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_TypesOfRealEstates_HouseType",
                        column: x => x.HouseType,
                        principalTable: "TypesOfRealEstates",
                        principalColumn: "HouseType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNumber = table.Column<string>(type: "char(10)", nullable: false, defaultValueSql: "FORMAT(NEXT VALUE FOR InvoiceNumbersSequence, '0000000000')"),
                    FiscalYear = table.Column<string>(type: "char(2)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromTheDateOf = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromTheDateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreviousConsumptionAmount = table.Column<int>(type: "int", nullable: false),
                    CurrentConsumptionAmount = table.Column<int>(type: "int", nullable: false),
                    AmountOfConsumption = table.Column<int>(type: "int", nullable: false),
                    ServiceFee = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TaxFee = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    SanitationIsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TheValueOfWaterConsumption = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    WasteWaterConsumptionValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalInvoice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalBill = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    InvoicesNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HouseType = table.Column<string>(type: "char(1)", nullable: false),
                    SubscriptionNumber = table.Column<string>(type: "char(10)", nullable: false),
                    SubscriberNumber = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNumber);
                    table.ForeignKey(
                        name: "FK_Invoices_Subscribers_SubscriberNumber",
                        column: x => x.SubscriberNumber,
                        principalTable: "Subscribers",
                        principalColumn: "PersonalIDNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Subscriptions_SubscriptionNumber",
                        column: x => x.SubscriptionNumber,
                        principalTable: "Subscriptions",
                        principalColumn: "SubscriptionNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_TypesOfRealEstates_HouseType",
                        column: x => x.HouseType,
                        principalTable: "TypesOfRealEstates",
                        principalColumn: "HouseType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HouseType",
                table: "Invoices",
                column: "HouseType");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SubscriberNumber",
                table: "Invoices",
                column: "SubscriberNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SubscriptionNumber",
                table: "Invoices",
                column: "SubscriptionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SlideDistributions_HouseType",
                table: "SlideDistributions",
                column: "HouseType");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_HouseType",
                table: "Subscriptions",
                column: "HouseType");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriberNumber",
                table: "Subscriptions",
                column: "SubscriberNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "SlideDistributions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "TypesOfRealEstates");

            migrationBuilder.DropSequence(
                name: "InvoiceNumbersSequence");
        }
    }
}
