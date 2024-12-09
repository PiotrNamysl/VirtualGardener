using Microsoft.EntityFrameworkCore;
using VirtualGardenerServer.Models;

namespace VirtualGardenerServer.Database;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PlantEntity> Plants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Email).IsUnique();
    }
}