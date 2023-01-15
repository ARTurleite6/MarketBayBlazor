using System;
using System.Security.Cryptography;
using MarketBayBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using MarketBayBlazor.Server.Controllers;


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
                    Foto = "https://images.unsplash.com/photo-1517694712202-14dd9538aa97?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=Mnw5MTMyMXwwfDF8c2VhcmNofDN8fGNvbXB1dGVyfGVufDB8fHx8MTY3MTY0ODk3Nw&ixlib=rb-4.0.3&q=80&w=400",
                };

                var categoria2 = new Categoria()
                {
                    Descricao = "Calçado",
                    Foto = "https://images.trustinnews.pt/uploads/sites/5/2022/09/21356781-1600x1067.jpg",
                };

                var categoria3 = new Categoria()
                {
                    Descricao = "Vestuário",
                    Foto = "https://imagens.bragatv.pt/wp-content/uploads/2022/08/01210208/feira-roupa.jpg",
                };

                var categoria4 = new Categoria()
                {
                    Descricao = "Livro",
                    Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSCxrfJzKH8GKhGsaFAKmd51U-i6a8xbUAbA&usqp=CAU",
                };

                this.Categorias.Add(categoria);
                this.Categorias.Add(categoria2);
                this.Categorias.Add(categoria3);
                this.Categorias.Add(categoria4);
                this.SaveChanges();
	        }

            if(!this.Feirantes.Any())
            {

                var password = "1234";
                FeiranteController.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                var feirante = new Feirante()
                {
                    NIFempresarial = "256250278",
                    Foto = "Foto de feirante",
                    Organizador = true,
                    Conta = new Conta()
                    {
                        Nome = "Artur Leite",
                        Email = "ajcl10@hotmail.com",
                        Password = passwordHash,
                        PasswordSalt = passwordSalt,
                        NumeroTelemovel = null,
                        Morada = new Morada()
                        {
                            Rua = "Rua de Babais",
                            CodigoPostal = "4650-063",
                            Localidade = "Felgueiras",
                        },
                    }
                };

                var feirante2 = new Feirante()
                {
                    NIFempresarial = "123456789",
                    Foto = "https://play-lh.googleusercontent.com/8_XBPWRyDYWFVyVBGJYKU_5d5hxZGCYeh4SUhGpcRCaz_PE8GMSA70I9wF-qA6DJxGg=w240-h480-rw",
                    Organizador = true,
                    Conta = new Conta()
                    {
                        Nome = "Worten",
                        Email = "worten@gmail.com",
                        Password = passwordHash,
                        PasswordSalt = passwordSalt,
                        NumeroTelemovel = null,
                        Morada = new Morada()
                        {
                            Rua = "Rua de Babais",
                            CodigoPostal = "4650-063",
                            Localidade = "Felgueiras",
                        },
                    }
                };


                var feirante3 = new Feirante()
                {
                    NIFempresarial = "157158159",
                    Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTI3n14QCYFrcpr1FtEyI0LsDlKd3unsczfpvOJe5-8qZp9VKcy_m5RXmuuzG63fUA_NEI&usqp=CAU",
                    Organizador = true,
                    Conta = new Conta()
                    {
                        Nome = "CESIUM",
                        Email = "cesium@hotmail.com",
                        Password = passwordHash,
                        PasswordSalt = passwordSalt,
                        NumeroTelemovel = null,
                        Morada = new Morada()
                        {
                            Rua = "Rua de Babais",
                            CodigoPostal = "4650-063",
                            Localidade = "Felgueiras",
                        },
                    }
                };

                var feirante4 = new Feirante()
                {
                    NIFempresarial = "321654987",
                    Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRTvEutXLvYjVY7VaOD1RVtaOregGFTsJjWAw&usqp=CAU",
                    Organizador = false,
                    Conta = new Conta()
                    {
                        Nome = "CEX",
                        Email = "cex@hotmail.com",
                        Password = passwordHash,
                        PasswordSalt = passwordSalt,
                        NumeroTelemovel = null,
                        Morada = new Morada()
                        {
                            Rua = "Rua de Babais",
                            CodigoPostal = "4650-063",
                            Localidade = "Felgueiras",
                        },
                    }
                };

                var feirante5 = new Feirante()
                {
                    NIFempresarial = "321654997",
                    Foto = "https://primedia.primark.com/i/primark/logo-primark",
                    Organizador = false,
                    Conta = new Conta()
                    {
                        Nome = "Primark",
                        Email = "primark@hotmail.com",
                        Password = passwordHash,
                        PasswordSalt = passwordSalt,
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
                this.Feirantes.Add(feirante2);
                this.Feirantes.Add(feirante3);
                this.Feirantes.Add(feirante4);
                this.Feirantes.Add(feirante5);
                this.SaveChanges();
	        }

            if(!this.Feiras.Any())
            {
                var feira1 = new Feira()
                {
                    NomeFeira = "Feira da ZaraHome",
                    Logotipo = "logotipo da feira",
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now.AddDays(20),
                    PrecoAluguel = 100.00M,
                    NumeroMaximoFeirantes = 10,
                    Organizador = this.Feirantes.Where(feirante => feirante.NIFempresarial == "256250278").First(),
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Vestuário").First(),
                };

                var feira2 = new Feira() 
                {
                    NomeFeira = "Semana de Engenharia Informática",
                    Logotipo = "Logotipo da feira",
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now.AddDays(20),
                    PrecoAluguel = 100.00M,
                    NumeroMaximoFeirantes = 10,
                    Organizador = this.Feirantes.Where(feirante => feirante.NIFempresarial == "256250278").First(),
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                };

                var feira3 = new Feira()
                {
                    NomeFeira = "Feira do Calçado Guimarães",
                    DataInicio = DateTime.Now.AddDays(5),
                    DataFim = DateTime.Now.AddDays(100),
                    PrecoAluguel = 100.00M,
                    NumeroMaximoFeirantes = 10,
                    Organizador = this.Feirantes.Where(feirante => feirante.NIFempresarial == "256250278").First(),
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Calçado").First(),
                };


                this.Feiras.Add(feira1);
                this.Feiras.Add(feira2);
                this.Feiras.Add(feira3);
                this.SaveChanges();
	        }

            if(!this.Produtos.Any())
            {
                this.Produtos.Add(new Produto()
                {
                    Nome = "MacbookPro",
                    Foto = "https://www.flash-keeper.com/wp-content/uploads/2020/08/pro13.png",
                    Descricao = "MacBookPro",
                    PrecoBase = 1000.00M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                }
                );

                this.Produtos.Add(new Produto()
                {
                    Nome = "IPhone14",
                    Foto = "https://www.digitaltrends.com/wp-content/uploads/2022/09/iPhone-14-Pro-Back-Purple-Hand.jpg?p=1",
                    Descricao = "IPhone14",
                    PrecoBase = 1000.00M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "GTA V PS4",
                    Foto = "https://www.leak.pt/wp-content/uploads/2019/07/gta.jpg",
                    PrecoBase = 25.00M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "GTA V PS5",
                    PrecoBase = 25.00M,
                    Foto = "https://www.leak.pt/wp-content/uploads/2019/07/gta.jpg",
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "The Last of Us Part II PS4",
                    Foto = "https://upload.wikimedia.org/wikipedia/pt/9/96/The_Last_of_Us_2_capa.png",
                    PrecoBase = 70.00M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "Hogwarts Legacy PS5",
                    Foto = "https://static.fnac-static.com/multimedia/Images/PT/NR/60/cc/80/8440928/1540-1.jpg",
                    PrecoBase = 74.99M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "Hogwarts Legacy PS5",
                    Foto = "https://static.fnac-static.com/multimedia/Images/PT/NR/60/cc/80/8440928/1540-1.jpg",
                    PrecoBase = 74.99M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "Horizon Forbidden West PS4",
                    Foto = "https://static.fnac-static.com/multimedia/Images/PT/NR/5c/b2/73/7582300/1540-1.jpg",
                    PrecoBase = 49.99M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "Like a Dragon - Ishin! - PS4",
                    Foto = "https://static.fnac-static.com/multimedia/Images/PT/NR/6e/fa/85/8780398/1540-1.jpg",
                    PrecoBase = 59.99M,
                    Categoria = this.Categorias.Where(categoria => categoria.Descricao == "Tecnologia").First(),
                });

                this.Produtos.Add(new Produto()
                {
                    Nome = "Pijama polar Playstation",
                    Foto = "https://primedia.primark.com/i/primark/210494201-01?w=2000&h=2000&img404=missing_product&v=1673811736700&locale=pt-*,en-*,*",
                    PrecoBase = 19.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Vestuário").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "T-Shirt malha rede San Diego",
                    Foto = "https://primedia.primark.com/i/primark/210639192-01?w=1000&h=1000&img404=missing_product&v=1673812576293&locale=pt-*,en-*,*",
                    PrecoBase = 12.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Vestuário").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "Pack 3 boxers riscas",
                    Foto = "https://primedia.primark.com/i/primark/210350011-01?w=2000&h=2000&img404=missing_product&v=1673812719092&locale=pt-*,en-*,*",
                    PrecoBase = 10.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Vestuário").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "Botas caminhada cordura c/atilhos",
                    Foto = "https://primedia.primark.com/i/primark/210362051-01?w=2000&h=2000&img404=missing_product&v=1673812995627&locale=pt-*,en-*,*",
                    PrecoBase = 26.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Calçado").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "Sandálias salto detalhe boca sino",
                    Foto = "https://primedia.primark.com/i/primark/210475267-01?w=2000&h=2000&img404=missing_product&v=1673813001308&locale=pt-*,en-*,*",
                    PrecoBase = 19.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Calçado").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "Botins rebordo pelo",
                    Foto = "https://primedia.primark.com/i/primark/210397725-01?w=2000&h=2000&img404=missing_product&v=1673813005676&locale=pt-*,en-*,*",
                    PrecoBase = 10.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Calçado").First(),
                });

                this.Produtos.Add(new Produto(){
                    Nome = "Ténis lona cano baixo",
                    Foto = "https://primedia.primark.com/i/primark/210303495-01?w=2000&h=2000&img404=missing_product&v=1673813010566&locale=pt-*,en-*,*",
                    PrecoBase = 6.00M,
                    Categoria = this.Categorias.Where(cat => cat.Descricao == "Calçado").First(),
                });

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

