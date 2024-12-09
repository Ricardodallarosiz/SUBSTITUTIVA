using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class bah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alunos", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "IMCs",
                columns: table => new
                {
                    IMCId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    peso = table.Column<double>(type: "REAL", nullable: false),
                    altura = table.Column<double>(type: "REAL", nullable: false),
                    ValorIMC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMCs", x => x.IMCId);
                    table.ForeignKey(
                        name: "FK_IMCs_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMCs_AlunoId",
                table: "IMCs",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMCs");

            migrationBuilder.DropTable(
                name: "alunos");
        }
    }
}
