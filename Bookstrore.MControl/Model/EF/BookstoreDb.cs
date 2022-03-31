using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bookstore.MControl
{
    public partial class BookstoreDb : DbContext
    {
        public BookstoreDb()
        {
        }

        public BookstoreDb(DbContextOptions<BookstoreDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<Decommissioned> Decommissioneds { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Publishing> Publishings { get; set; }
        public virtual DbSet<Reserf> Reserves { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conString = Connection();
                optionsBuilder.UseSqlite($"Data Source={conString}");
            }
        }

        private string Connection()
        {
            return File.ReadAllText("Connection.txt");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Accounts_id")
                    .IsUnique();

                entity.HasIndex(e => e.Mail, "IX_Accounts_mail")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Accounts_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Actions_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Actions_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasColumnName("end_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Authors_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Authors_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Books_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Books_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AutorId).HasColumnName("autor_id");

                entity.Property(e => e.CycleId).HasColumnName("cycle_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Clients_id")
                    .IsUnique();

                entity.HasIndex(e => e.Mail, "IX_Clients_mail")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Cycles_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Cycles_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Decommissioned>(entity =>
            {
                entity.ToTable("Decommissioned");

                entity.HasIndex(e => e.Id, "IX_Decommissioned_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Decommissioneds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Genres_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Genres_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Publications_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BiikId).HasColumnName("biik_id");

                entity.Property(e => e.CostPrice).HasColumnName("cost_price");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.PublishingId).HasColumnName("publishing_id");

                entity.Property(e => e.SeriesId).HasColumnName("series_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Biik)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.BiikId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Publishing)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.PublishingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Publishing>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Publishings_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Publishings_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Reserf>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Reserves_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Sales_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Series_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Series_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.Id, "IX_Store_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionId).HasColumnName("action_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Tags_id")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Tags_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
