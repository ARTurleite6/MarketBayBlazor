using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProdutoDestacado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Destacado",
                table: "ProdutoStand",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destacado",
                table: "ProdutoStand");
        }
    }
}
