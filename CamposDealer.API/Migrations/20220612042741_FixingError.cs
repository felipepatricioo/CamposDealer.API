using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamposDealer.API.Migrations
{
    public partial class FixingError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Cliente");
        }
    }
}
