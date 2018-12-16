using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacies.Data.Migrations
{
    public partial class Update_PharmaciesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Pharmacists_PharmacistId",
                table: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Pharmacists");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_PharmacistId",
                table: "Pharmacies");

            migrationBuilder.RenameColumn(
                name: "PharmacistId",
                table: "Pharmacies",
                newName: "PharmaciesUserId");

            migrationBuilder.AddColumn<string>(
                name: "MenagerId",
                table: "Pharmacies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_AspNetUsers_MenagerId",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_MenagerId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "MenagerId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PharmaciesUserId",
                table: "Pharmacies",
                newName: "PharmacistId");

            migrationBuilder.CreateTable(
                name: "Pharmacists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Uin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_PharmacistId",
                table: "Pharmacies",
                column: "PharmacistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Pharmacists_PharmacistId",
                table: "Pharmacies",
                column: "PharmacistId",
                principalTable: "Pharmacists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
