using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacies.Data.Migrations
{
    public partial class ModifyPharmaciesManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_MenagerId",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_MenagerId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "PharmaciesUserId",
                table: "Pharmacies");

            migrationBuilder.RenameColumn(
                name: "MenagerId",
                table: "Pharmacies",
                newName: "Manager");

            migrationBuilder.AlterColumn<string>(
                name: "Manager",
                table: "Pharmacies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Pharmacies",
                newName: "MenagerId");

            migrationBuilder.AlterColumn<string>(
                name: "MenagerId",
                table: "Pharmacies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PharmaciesUserId",
                table: "Pharmacies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_MenagerId",
                table: "Pharmacies",
                column: "MenagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_AspNetUsers_MenagerId",
                table: "Pharmacies",
                column: "MenagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
