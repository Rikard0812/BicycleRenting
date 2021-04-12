using Microsoft.EntityFrameworkCore.Migrations;

namespace BicycleRenting.Migrations
{
    public partial class UpdateRelationshipsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_Brands_BrandBicycleBrand",
                table: "Bicycles");

            migrationBuilder.RenameColumn(
                name: "BrandBicycleBrand",
                table: "Bicycles",
                newName: "BrandForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Bicycles_BrandBicycleBrand",
                table: "Bicycles",
                newName: "IX_Bicycles_BrandForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_Brands_BrandForeignKey",
                table: "Bicycles",
                column: "BrandForeignKey",
                principalTable: "Brands",
                principalColumn: "BicycleBrand",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_Brands_BrandForeignKey",
                table: "Bicycles");

            migrationBuilder.RenameColumn(
                name: "BrandForeignKey",
                table: "Bicycles",
                newName: "BrandBicycleBrand");

            migrationBuilder.RenameIndex(
                name: "IX_Bicycles_BrandForeignKey",
                table: "Bicycles",
                newName: "IX_Bicycles_BrandBicycleBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_Brands_BrandBicycleBrand",
                table: "Bicycles",
                column: "BrandBicycleBrand",
                principalTable: "Brands",
                principalColumn: "BicycleBrand",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
