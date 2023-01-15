using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class fotoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Categoria",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Categoria");
        }
    }
}
