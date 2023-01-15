using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class FotosTamanho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Produto",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Feirante",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Categoria",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Produto",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 100000);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Feirante",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 100000);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Categoria",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 100000);
        }
    }
}
