using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class insertInitialDataHabilidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "habilidades",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "Angular" },
                    { 4, "SQL" },
                    { 5, "ASP" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "habilidades",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "habilidades",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "habilidades",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "habilidades",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "habilidades",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
