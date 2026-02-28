using Microsoft.EntityFrameworkCore;
using ReviewSystem.Models;

namespace ReviewSystem.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================= USERS =================
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(u => u.Id);

                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(u => u.Role)
                      .IsRequired()
                      .HasMaxLength(20);
            });

            // ================= PRODUCTS =================
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(p => p.Price)
                      .HasColumnType("decimal(10,2)");
            });

            // ================= ORDERS =================
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.HasKey(o => o.Id);

                entity.HasOne(o => o.User)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(o => o.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ================= ORDER ITEMS =================
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");

                entity.HasKey(oi => oi.Id);

                entity.HasOne(oi => oi.Order)
                      .WithMany(o => o.OrderItems)
                      .HasForeignKey(oi => oi.OrderId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(oi => oi.Product)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(oi => oi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ================= REVIEWS =================
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews", tableBuilder =>
                {
                    tableBuilder.HasCheckConstraint(
                        "CK_Reviews_Rating",
                        "Rating BETWEEN 1 AND 5");
                });

                entity.HasKey(r => r.Id);

                entity.HasIndex(r => new { r.ProductId, r.UserId })
                      .IsUnique();

                entity.Property(r => r.Rating)
                      .IsRequired();

                entity.Property(r => r.Comment)
                      .IsRequired();

                entity.Property(r => r.Status)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.HasOne(r => r.Product)
                      .WithMany(p => p.Reviews)
                      .HasForeignKey(r => r.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reviews)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}