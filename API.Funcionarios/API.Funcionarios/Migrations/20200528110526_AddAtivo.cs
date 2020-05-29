using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class AddAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "funcionarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "funcionarios");
        }
    }
}
