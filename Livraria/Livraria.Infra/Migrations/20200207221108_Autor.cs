using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class Autor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    NomeAutor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Autor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
