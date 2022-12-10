using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipClienteConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraProduto_Compra_CompraID",
                table: "CompraProduto");

            migrationBuilder.DropIndex(
                name: "IX_Feirante_ContaID",
                table: "Feirante");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_ContaID",
                table: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Feirante_ContaID",
                table: "Feirante",
                column: "ContaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContaID",
                table: "Cliente",
                column: "ContaID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feirante_ContaID",
                table: "Feirante");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_ContaID",
                table: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Feirante_ContaID",
                table: "Feirante",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContaID",
                table: "Cliente",
                column: "ContaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraProduto_Compra_CompraID",
                table: "CompraProduto",
                column: "CompraID",
                principalTable: "Compra",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
