using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class id_funcionario_habilidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "funcionario_habilidades",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_funcionario_habilidades",
                table: "funcionario_habilidades",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_funcionario_habilidades",
                table: "funcionario_habilidades");

            migrationBuilder.DropColumn(
                name: "id",
                table: "funcionario_habilidades");
        }
    }
}
