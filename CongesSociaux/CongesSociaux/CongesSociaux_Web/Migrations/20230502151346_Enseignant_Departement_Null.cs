using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongesSociaux_Web.Migrations
{
    public partial class Enseignant_Departement_Null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Departements_DepartementId",
                table: "Enseignants");

            migrationBuilder.AlterColumn<int>(
                name: "DepartementId",
                table: "Enseignants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Departements_DepartementId",
                table: "Enseignants",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enseignants_Departements_DepartementId",
                table: "Enseignants");

            migrationBuilder.AlterColumn<int>(
                name: "DepartementId",
                table: "Enseignants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignants_Departements_DepartementId",
                table: "Enseignants",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
