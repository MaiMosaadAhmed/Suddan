using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuddanApplication.Infrastructure.Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_OwnerCars_OwnerCarId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_OwnerCarId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "OwnerCarId",
                table: "Drivers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerCarId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_OwnerCarId",
                table: "Drivers",
                column: "OwnerCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_OwnerCars_OwnerCarId",
                table: "Drivers",
                column: "OwnerCarId",
                principalTable: "OwnerCars",
                principalColumn: "Id");
        }
    }
}
