using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Infra.Migrations
{
    public partial class Exemplar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exemplar",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    NomeExemplar = table.Column<string>(nullable: true),
                    NumeroPaginas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Exemplar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemplar");
        }
    }
}
