using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Morada",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaID = table.Column<int>(type: "int", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morada", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PrecoBase = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroTelemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    MoradaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conta_Morada_MoradaID",
                        column: x => x.MoradaID,
                        principalTable: "Morada",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cliente_Conta_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Conta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feirante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIFempresarial = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Organizador = table.Column<bool>(type: "bit", nullable: false),
                    ContaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feirante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feirante_Conta_ContaID",
                        column: x => x.ContaID,
                        principalTable: "Conta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaCliente",
                columns: table => new
                {
                    CategoriasID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCliente", x => new { x.CategoriasID, x.ClienteID });
                    table.ForeignKey(
                        name: "FK_CategoriaCliente_Categoria_CategoriasID",
                        column: x => x.CategoriasID,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaCliente_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassificacoesCliente",
                columns: table => new
                {
                    FeiranteID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacoesCliente", x => new { x.FeiranteID, x.ClienteID });
                    table.ForeignKey(
                        name: "FK_ClassificacoesCliente_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassificacoesCliente_Feirante_FeiranteID",
                        column: x => x.FeiranteID,
                        principalTable: "Feirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Feira",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFeira = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logotipo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoAluguel = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    NumeroMaximoFeirantes = table.Column<int>(type: "int", nullable: false),
                    FeiranteID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feira", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feira_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feira_Feirante_FeiranteID",
                        column: x => x.FeiranteID,
                        principalTable: "Feirante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioFeirante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Aceite = table.Column<bool>(type: "bit", nullable: false),
                    FeiranteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioFeirante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormularioFeirante_Feirante_FeiranteID",
                        column: x => x.FeiranteID,
                        principalTable: "Feirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FavFeirasCliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    FeiraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavFeirasCliente", x => new { x.ClienteID, x.FeiraID });
                    table.ForeignKey(
                        name: "FK_FavFeirasCliente_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavFeirasCliente_Feira_FeiraID",
                        column: x => x.FeiraID,
                        principalTable: "Feira",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StandFeirante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    FeiranteID = table.Column<int>(type: "int", nullable: false),
                    FeiraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandFeirante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StandFeirante_Feira_FeiraID",
                        column: x => x.FeiraID,
                        principalTable: "Feira",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandFeirante_Feirante_FeiranteID",
                        column: x => x.FeiranteID,
                        principalTable: "Feirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    StandFeiranteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Compra_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_StandFeirante_StandFeiranteID",
                        column: x => x.StandFeiranteID,
                        principalTable: "StandFeirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoStand",
                columns: table => new
                {
                    StandFeiranteID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoStand", x => new { x.StandFeiranteID, x.ProdutoID });
                    table.ForeignKey(
                        name: "FK_ProdutoStand_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProdutoStand_StandFeirante_StandFeiranteID",
                        column: x => x.StandFeiranteID,
                        principalTable: "StandFeirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Proposta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    StandFeiranteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proposta_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposta_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposta_StandFeirante_StandFeiranteID",
                        column: x => x.StandFeiranteID,
                        principalTable: "StandFeirante",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CompraProduto",
                columns: table => new
                {
                    CompraID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProduto", x => new { x.CompraID, x.ProdutoID });
                    table.ForeignKey(
                        name: "FK_CompraProduto_Compra_CompraID",
                        column: x => x.CompraID,
                        principalTable: "Compra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaCliente_ClienteID",
                table: "CategoriaCliente",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacoesCliente_ClienteID",
                table: "ClassificacoesCliente",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ContaID",
                table: "Cliente",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ClienteID",
                table: "Compra",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_StandFeiranteID",
                table: "Compra",
                column: "StandFeiranteID");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_ProdutoID",
                table: "CompraProduto",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_Email",
                table: "Conta",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conta_MoradaID",
                table: "Conta",
                column: "MoradaID",
                unique: true,
                filter: "[MoradaID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavFeirasCliente_FeiraID",
                table: "FavFeirasCliente",
                column: "FeiraID");

            migrationBuilder.CreateIndex(
                name: "IX_Feira_CategoriaID",
                table: "Feira",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Feira_FeiranteID",
                table: "Feira",
                column: "FeiranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Feirante_ContaID",
                table: "Feirante",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Feirante_NIFempresarial",
                table: "Feirante",
                column: "NIFempresarial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormularioFeirante_FeiranteID",
                table: "FormularioFeirante",
                column: "FeiranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaID",
                table: "Produto",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoStand_ProdutoID",
                table: "ProdutoStand",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ClienteID",
                table: "Proposta",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ProdutoID",
                table: "Proposta",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_StandFeiranteID",
                table: "Proposta",
                column: "StandFeiranteID");

            migrationBuilder.CreateIndex(
                name: "IX_StandFeirante_FeiraID",
                table: "StandFeirante",
                column: "FeiraID");

            migrationBuilder.CreateIndex(
                name: "IX_StandFeirante_FeiranteID",
                table: "StandFeirante",
                column: "FeiranteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaCliente");

            migrationBuilder.DropTable(
                name: "ClassificacoesCliente");

            migrationBuilder.DropTable(
                name: "CompraProduto");

            migrationBuilder.DropTable(
                name: "FavFeirasCliente");

            migrationBuilder.DropTable(
                name: "FormularioFeirante");

            migrationBuilder.DropTable(
                name: "ProdutoStand");

            migrationBuilder.DropTable(
                name: "Proposta");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "StandFeirante");

            migrationBuilder.DropTable(
                name: "Feira");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Feirante");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Morada");
        }
    }
}
