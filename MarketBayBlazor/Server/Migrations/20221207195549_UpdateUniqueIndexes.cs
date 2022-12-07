using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Descricao",
                table: "Categoria",
                column: "Descricao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categoria_Descricao",
                table: "Categoria");
        }
    }
}
