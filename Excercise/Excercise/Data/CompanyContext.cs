using Excercise.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Excercise.Data
{
    public class CompanyContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> ProductOwnert { get; set; }
        public DbSet<Status> Status { get; set; }

        public CompanyContext(DbContextOptions options) : base(options)
        {
        }

        public CompanyContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Price).IsRequired();
               
                entity.HasData(new List<Product>()
                {
                    new Product
                    {
                        Id = 1,
                        Name = "ksiazka",
                        Price = 12
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "dlugopis",
                        Price = 10
                    }
                });

            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();

                entity.HasData(new List<Client>()
                {
                    new Client
                    {
                        Id = 1,
                        FirstName = "Jan",
                        LastName = "Kowalski"
                    },
                    new Client
                    {
                        Id = 2,
                        FirstName = "Marcin",
                        LastName = "Brzechwa"
                    }
                });

            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();

                entity.HasData(new List<Status>()
                {
                    new Status
                    {
                        Id = 1,
                        Name = "Done",
                    },
                    new Status
                    {
                        Id = 2,
                        Name = "Processing",
                    }
                });

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.FulFilledAt).IsRequired(false);

                entity.HasOne(e => e.Client)
                     .WithMany(e => e.Order)
                     .HasForeignKey(e => e.ClientId)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Status)
                     .WithMany(e => e.Order)
                     .HasForeignKey(e => e.StatusId)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(new List<Order>()
                {
                    new Order
                    {
                        Id = 1,
                        CreatedAt = new DateTime(1999, 2, 15),
                        FulFilledAt = new DateTime(1999, 2, 16),
                        ClientId= 1,
                        StatusId = 1
                    },
                    new Order
                    {
                        Id = 2,
                        CreatedAt = new DateTime(2000, 2, 1),
                        FulFilledAt = new DateTime(2000, 2, 2),
                        ClientId= 2,
                        StatusId = 2
                    }
                });

            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("Product_Order");
                entity.HasKey(e => new { e.ProductId, e.OrderId }); 
                entity.Property(e => e.Amount).IsRequired();


                entity.HasOne(e => e.Product)
                     .WithMany(e => e.ProductOrder)
                     .HasForeignKey(e => e.ProductId)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Order)
                     .WithMany(e => e.ProductOrder)
                     .HasForeignKey(e => e.OrderId)
                     .OnDelete(DeleteBehavior.Cascade);


                entity.HasData(new List<ProductOrder>()
                {
                    new ProductOrder
                    {
                        ProductId= 1,
                        OrderId= 1,
                        Amount = 10
                    },
                    new ProductOrder
                    {
                        ProductId= 2,
                        OrderId= 2,
                        Amount = 111
                    }
                });

            });

        }

    }
}
