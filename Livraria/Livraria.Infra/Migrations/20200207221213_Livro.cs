using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class Livro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    NomeLivro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Livro", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
