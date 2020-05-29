using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class noIdentityFH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario_habilidades");

            migrationBuilder.CreateTable(
                name: "FuncionarioHabilidades",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false),
                    HabilidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioHabilidades");

            migrationBuilder.CreateTable(
                name: "funcionario_habilidades",
                columns: table => new
                {
                    funcionario_id = table.Column<int>(type: "int", nullable: false),
                    habilidade_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario_habilidades", x => new { x.funcionario_id, x.habilidade_id });
                    table.ForeignKey(
                        name: "FK_funcionario_habilidades_funcionarios_funcionario_id",
                        column: x => x.funcionario_id,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_funcionario_habilidades_habilidades_habilidade_id",
                        column: x => x.habilidade_id,
                        principalTable: "habilidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_habilidades_habilidade_id",
                table: "funcionario_habilidades",
                column: "habilidade_id");
        }
    }
}
