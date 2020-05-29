using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class noIdentityFH2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "FuncionarioHabilidades",
                newName: "funcionario_habilidades");

            migrationBuilder.RenameColumn(
                name: "HabilidadeId",
                table: "funcionario_habilidades",
                newName: "habilidade_id");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "funcionario_habilidades",
                newName: "funcionario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "funcionario_habilidades",
                newName: "FuncionarioHabilidades");

            migrationBuilder.RenameColumn(
                name: "habilidade_id",
                table: "FuncionarioHabilidades",
                newName: "HabilidadeId");

            migrationBuilder.RenameColumn(
                name: "funcionario_id",
                table: "FuncionarioHabilidades",
                newName: "FuncionarioId");
        }
    }
}
