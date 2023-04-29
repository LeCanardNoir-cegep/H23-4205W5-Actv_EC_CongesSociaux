using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongesSociaux_Web.Migrations
{
    public partial class Add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, 300, "Informatique" });

            migrationBuilder.InsertData(
                table: "Soutiens",
                columns: new[] { "Id", "DateEmbauche", "Nom", "Poste", "Prenom" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "La Moppe", "Youpie", "Viateur" });

            migrationBuilder.InsertData(
                table: "Enseignants",
                columns: new[] { "Id", "DateEmbauche", "DepartementId", "Nom", "Prenom", "Specialite" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Trop-Moche", "Jacques", "On cherche toujours" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enseignants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Soutiens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departements",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
