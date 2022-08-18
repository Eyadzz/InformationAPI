using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Information>()
            .HasOne<Category>()
            .WithMany()
            .HasForeignKey(c => c.CategoryId);
        modelBuilder.Entity<Category>()
            .HasIndex(s => s.Name)
            .IsUnique();
        modelBuilder.Entity<Category>().HasData(
            new List<Category>
            {
                new Category
                {
                    CategoryId = 1,
                    Name = "Not Important"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Important"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Very Important"
                }
            });
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Information> Information { get; set; }
}