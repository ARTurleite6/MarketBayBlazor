using System;
using MarketBayBlazor.Shared;
using Microsoft.EntityFrameworkCore;


namespace MarketBayBlazor.Server.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public void InitializeDatabase() 
	    {
            if(!this.Categorias.Any())
            {
                Console.WriteLine("Nova Categoria");
                var categoria = new Categoria()
                {
                    Descricao = "Tecnologia",
                };
                this.Categorias.Add(categoria);
                this.SaveChanges();
	        }

            if(!this.Feirantes.Any())
            {
                var feirante = new Feirante()
                {
                    NIFempresarial = "256250278",
                    Foto = "Foto de feirante",
                    Organizador = true,
                    Conta = new Conta()
                    {
                        Nome = "Artur Leite",
                        Email = "ajcl10@hotmail.com",
                        Password = "12345",
                        NumeroTelemovel = null,
                        Morada = new Morada()
                        {
                            Rua = "Rua de Babais",
                            CodigoPostal = "4650-063",
                            Localidade = "Felgueiras",
                        },
                    }
                };
                this.Feirantes.Add(feirante);
                this.SaveChanges();
	        }

            if(!this.Feiras.Any())
            {
                var feira1 = new Feira()
                {
                    NomeFeira = "Ze do Dizes",
                    Logotipo = "logotipo da feira",
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now,
                    PrecoAluguel = 100.00M,
                    NumeroMaximoFeirantes = 10,
                    Organizador = this.Feirantes.Where(feirante => feirante.NIFempresarial == "256250278").First(),
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                };


                this.Feiras.Add(feira1);
                this.SaveChanges();
	        }

            if(!this.StandsFeirantes.Any())
            { 
                var stand = new StandFeirante()
                {
                    FeiranteID = 1,
                    FeiraID = 1,
                };
                this.StandsFeirantes.Add(stand);
                this.SaveChanges();
	        }
	    }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StandFeirante>()
                .HasOne<Feirante>(f => f.Feirante)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Compra>()
                .HasOne<StandFeirante>()
                .WithMany(s => s.Vendas)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Compra>()
                .HasMany<CompraProduto>(compra => compra.CompraProdutos)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ClassificacoesCliente>()
                .HasOne<Feirante>()
                .WithMany(f => f.ClassificacoesClientes)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Proposta>()
                .HasOne<StandFeirante>()
                .WithMany(s => s.Propostas)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Cliente>()
                .HasMany<Categoria>(cliente => cliente.Categorias)
                .WithMany();

            modelBuilder.Entity<FavFeirasCliente>()
                .HasOne<Cliente>()
                .WithMany(c => c.FeirasFavoritas);

            modelBuilder.Entity<FavFeirasCliente>()
                .HasOne<Feira>()
                .WithMany()
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Conta>()
                .HasOne<Morada>(conta => conta.Morada)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Conta>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Feirante>()
                .HasIndex(c => c.NIFempresarial)
                .IsUnique();

            modelBuilder.Entity<Feirante>()
                .HasIndex(f => f.NIFempresarial)
                .IsUnique();

            modelBuilder.Entity<ProdutoStand>()
                .HasOne<StandFeirante>()
                .WithMany(stand => stand.ProdutosStands)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ProdutoStand>()
                .HasOne<Produto>(p => p.Produto)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Categoria>()
                .HasIndex(categoria => categoria.Descricao)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasOne<Conta>(c => c.Conta)
                .WithOne();

            modelBuilder.Entity<Feirante>()
                .HasOne<Conta>(c => c.Conta)
                .WithOne();

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ClassificacoesCliente> ClassificacoesCliente { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraProduto> ComprasProdutos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<FavFeirasCliente> FeirasClienteFavoritas { get; set; }
        public DbSet<Feira> Feiras { get; set; }
        public DbSet<Feirante> Feirantes { get; set; }
        public DbSet<FormularioFeirante> FormulariosFeirantes { get; set; }
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoStand> ProdutosStands { get; set; }
        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<StandFeirante> StandsFeirantes { get; set; }
    }


}

