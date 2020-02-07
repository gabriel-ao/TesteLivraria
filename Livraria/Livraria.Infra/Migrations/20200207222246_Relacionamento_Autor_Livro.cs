using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class Relacionamento_Autor_Livro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AutorId",
                table: "Livro",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorId",
                table: "Livro",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Autor_AutorId",
                table: "Livro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Autor_AutorId",
                table: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Livro_AutorId",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Livro");
        }
    }
}
