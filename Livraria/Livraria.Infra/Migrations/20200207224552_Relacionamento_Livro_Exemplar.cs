using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class Relacionamento_Livro_Exemplar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LivroId",
                table: "Exemplar",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exemplar_LivroId",
                table: "Exemplar",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exemplar_Livro_LivroId",
                table: "Exemplar",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exemplar_Livro_LivroId",
                table: "Exemplar");

            migrationBuilder.DropIndex(
                name: "IX_Exemplar_LivroId",
                table: "Exemplar");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Exemplar");
        }
    }
}
