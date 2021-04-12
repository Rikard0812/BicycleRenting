using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BicycleRenting.Migrations
{
    public partial class InitialCreateBicycleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BicycleBrand = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BicycleBrand);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    BicycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    BrandBicycleBrand = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.BicycleId);
                    table.ForeignKey(
                        name: "FK_Bicycles_Brands_BrandBicycleBrand",
                        column: x => x.BrandBicycleBrand,
                        principalTable: "Brands",
                        principalColumn: "BicycleBrand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BicycleReservation",
                columns: table => new
                {
                    BicyclesBicycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationsReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleReservation", x => new { x.BicyclesBicycleId, x.ReservationsReservationId });
                    table.ForeignKey(
                        name: "FK_BicycleReservation_Bicycles_BicyclesBicycleId",
                        column: x => x.BicyclesBicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BicycleReservation_Reservations_ReservationsReservationId",
                        column: x => x.ReservationsReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BicycleReservation_ReservationsReservationId",
                table: "BicycleReservation",
                column: "ReservationsReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycles_BrandBicycleBrand",
                table: "Bicycles",
                column: "BrandBicycleBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BicycleReservation");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
