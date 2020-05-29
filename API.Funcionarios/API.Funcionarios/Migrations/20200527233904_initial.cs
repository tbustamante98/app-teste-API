using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Funcionarios.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_completo = table.Column<string>(type: "varchar(255)", nullable: false),
                    nascimento = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: true),
                    sexo = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "habilidades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habilidades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcionario_habilidades",
                columns: table => new
                {
                    funcionario_id = table.Column<int>(nullable: false),
                    habilidade_id = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionario_habilidades");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "habilidades");
        }
    }
}
