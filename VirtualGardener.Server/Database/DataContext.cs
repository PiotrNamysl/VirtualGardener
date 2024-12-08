using Microsoft.EntityFrameworkCore;
using VirtualGardenerServer.Models;

namespace VirtualGardenerServer.Database;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email).IsUnique();
    }
}