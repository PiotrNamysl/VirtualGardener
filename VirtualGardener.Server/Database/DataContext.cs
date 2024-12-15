using Microsoft.EntityFrameworkCore;
using VirtualGardener.Client.Models;
using VirtualGardenerServer.Models;

namespace VirtualGardenerServer.Database;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<CareTask> CareTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Email).IsUnique();
    }
}