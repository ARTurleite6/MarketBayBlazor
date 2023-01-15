﻿// <auto-generated />
using System;
using MarketBayBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketBayBlazor.Server.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230115154944_Fotole")]
    partial class Fotole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoriaCliente", b =>
                {
                    b.Property<int>("CategoriasID")
                        .HasColumnType("int");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.HasKey("CategoriasID", "ClienteID");

                    b.HasIndex("ClienteID");

                    b.ToTable("CategoriaCliente");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Categoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.ClassificacoesCliente", b =>
                {
                    b.Property<int>("FeiranteID")
                        .HasColumnType("int");

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("FeiranteID", "ClienteID");

                    b.HasIndex("ClienteID");

                    b.ToTable("ClassificacoesCliente");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ContaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContaID")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Compra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("StandFeiranteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("StandFeiranteID");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.CompraProduto", b =>
                {
                    b.Property<int>("CompraID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CompraID", "ProdutoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("CompraProduto");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Conta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("MoradaID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroTelemovel")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MoradaID")
                        .IsUnique()
                        .HasFilter("[MoradaID] IS NOT NULL");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.FavFeirasCliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<int>("FeiraID")
                        .HasColumnType("int");

                    b.HasKey("ClienteID", "FeiraID");

                    b.HasIndex("FeiraID");

                    b.ToTable("FavFeirasCliente");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feira", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("FeiranteID")
                        .HasColumnType("int");

                    b.Property<string>("Logotipo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeFeira")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumeroMaximoFeirantes")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoAluguel")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("FeiranteID");

                    b.ToTable("Feira");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feirante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ContaID")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NIFempresarial")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<bool>("Organizador")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("ContaID")
                        .IsUnique();

                    b.HasIndex("NIFempresarial")
                        .IsUnique();

                    b.ToTable("Feirante");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.FormularioFeirante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Aceite")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("FeiranteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FeiranteID");

                    b.ToTable("FormularioFeirante");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Morada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Morada");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PrecoBase")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.ProdutoStand", b =>
                {
                    b.Property<int>("StandFeiranteID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<bool>("Destacado")
                        .HasColumnType("bit");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("StandFeiranteID", "ProdutoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("ProdutoStand");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Proposta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("StandFeiranteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProdutoID");

                    b.HasIndex("StandFeiranteID");

                    b.ToTable("Proposta");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.StandFeirante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FeiraID")
                        .HasColumnType("int");

                    b.Property<int>("FeiranteID")
                        .HasColumnType("int");

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("FeiraID");

                    b.HasIndex("FeiranteID");

                    b.ToTable("StandFeirante");
                });

            modelBuilder.Entity("CategoriaCliente", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.ClassificacoesCliente", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Feirante", null)
                        .WithMany("ClassificacoesClientes")
                        .HasForeignKey("FeiranteID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Cliente", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Conta", "Conta")
                        .WithOne()
                        .HasForeignKey("MarketBayBlazor.Shared.Cliente", "ContaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Compra", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Cliente", null)
                        .WithMany("Compras")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.StandFeirante", null)
                        .WithMany("Vendas")
                        .HasForeignKey("StandFeiranteID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.CompraProduto", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Compra", null)
                        .WithMany("CompraProdutos")
                        .HasForeignKey("CompraID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Conta", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Morada", "Morada")
                        .WithOne()
                        .HasForeignKey("MarketBayBlazor.Shared.Conta", "MoradaID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Morada");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.FavFeirasCliente", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Cliente", null)
                        .WithMany("FeirasFavoritas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Feira", null)
                        .WithMany()
                        .HasForeignKey("FeiraID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feira", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Feirante", "Organizador")
                        .WithMany()
                        .HasForeignKey("FeiranteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feirante", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Conta", "Conta")
                        .WithOne()
                        .HasForeignKey("MarketBayBlazor.Shared.Feirante", "ContaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.FormularioFeirante", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Feirante", null)
                        .WithMany("Formularios")
                        .HasForeignKey("FeiranteID");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Produto", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.ProdutoStand", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.StandFeirante", null)
                        .WithMany("ProdutosStands")
                        .HasForeignKey("StandFeiranteID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Proposta", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.StandFeirante", null)
                        .WithMany("Propostas")
                        .HasForeignKey("StandFeiranteID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.StandFeirante", b =>
                {
                    b.HasOne("MarketBayBlazor.Shared.Feira", null)
                        .WithMany("Stands")
                        .HasForeignKey("FeiraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketBayBlazor.Shared.Feirante", "Feirante")
                        .WithMany()
                        .HasForeignKey("FeiranteID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Feirante");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Cliente", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("FeirasFavoritas");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Compra", b =>
                {
                    b.Navigation("CompraProdutos");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feira", b =>
                {
                    b.Navigation("Stands");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.Feirante", b =>
                {
                    b.Navigation("ClassificacoesClientes");

                    b.Navigation("Formularios");
                });

            modelBuilder.Entity("MarketBayBlazor.Shared.StandFeirante", b =>
                {
                    b.Navigation("ProdutosStands");

                    b.Navigation("Propostas");

                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
