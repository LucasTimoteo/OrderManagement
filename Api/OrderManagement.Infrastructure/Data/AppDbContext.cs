using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using System.Reflection.Emit;

namespace OrderManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<StockProduct> StockProducts { get; set; }
    public DbSet<ProductPromotion> ProductPromotions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(e =>
        {
            e.HasKey(o => o.Id);
            e.HasIndex(o => o.Number).IsUnique();
            e.Property(o => o.GrossTotal).HasColumnType("decimal(18,2)");
            e.Property(o => o.Discount).HasColumnType("decimal(18,2)");
            e.Property(o => o.NetTotal).HasColumnType("decimal(18,2)");
            e.HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Client>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).HasMaxLength(200).IsRequired();
            e.Property(c => c.Email).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasIndex(p => p.Sku).IsUnique();
            e.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<OrderItem>(e =>
        {
            e.HasKey(oi => oi.Id);
            e.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
            e.Property(oi => oi.Discount).HasColumnType("decimal(18,2)");
            e.Property(oi => oi.Total).HasColumnType("decimal(18,2)");
            e.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Promotion>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Percent).HasColumnType("decimal(5,2)");
            e.Property(p => p.FixedAmount).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Stock>(e =>
        {
            e.HasKey(s => s.Id);
            e.Property(s => s.Name).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<StockProduct>(e =>
        {
            e.HasKey(sp => new { sp.StockId, sp.ProductId });
            e.Property(sp => sp.Qty).HasColumnType("int").IsRequired();
            e.HasOne(sp => sp.Stock)
                .WithMany(s => s.StockProducts)
                .HasForeignKey(sp => sp.StockId);
            e.HasOne(sp => sp.Product)
                .WithMany(p => p.StockProducts)
                .HasForeignKey(sp => sp.ProductId);
        });

        modelBuilder.Entity<ProductPromotion>(e =>
        {
            e.HasKey(sp => new { sp.PromotionId, sp.ProductId });
            e.HasOne(sp => sp.Promotion)
                .WithMany(s => s.ProductPromotions)
                .HasForeignKey(sp => sp.PromotionId);
            e.HasOne(sp => sp.Product)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(sp => sp.ProductId);
        });
    }

}