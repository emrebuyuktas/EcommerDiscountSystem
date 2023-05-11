using EcommerDiscountSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerDiscountSystem;
public interface IAppDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Discount> Discounts { get; set; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void SaveChanges();
}
public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    public void SaveChanges()
    {
        base.SaveChanges();
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>().HasKey(x => x.Id);
        modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Discount>().HasKey(x => x.Id);
        modelBuilder.Entity<Discount>().Property(x => x.Id).ValueGeneratedOnAdd();
        
        
        modelBuilder.Entity<Product>().Property(x=>x.Price).HasPrecision(14, 2);
        modelBuilder.Entity<Discount>().Property(x=>x.Rate).HasPrecision(14, 2);
        modelBuilder.Entity<Category>().Property(x => x.DiscountId).IsRequired(false);
        modelBuilder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Category>().HasOne<Discount>(c => c.Discount).WithMany(d => d.Categories).HasForeignKey(c => c.DiscountId);
    }
}