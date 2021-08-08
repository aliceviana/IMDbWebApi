using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDb.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Diretor = table.Column<string>(type: "varchar(255)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    Role = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ator",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ator_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Nota = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voto_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ator_FilmeId",
                table: "Ator",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_FilmeId",
                table: "Voto",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_UsuarioId",
                table: "Voto",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ator");

            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
