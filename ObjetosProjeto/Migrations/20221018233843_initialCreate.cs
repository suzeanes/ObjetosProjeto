using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObjetosProjeto.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContatoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchadoPerdido = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetoModel_ContatoModel_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "ContatoModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjetoModel_ContatoId",
                table: "ObjetoModel",
                column: "ContatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjetoModel");

            migrationBuilder.DropTable(
                name: "ContatoModel");
        }
    }
}
