using Microsoft.EntityFrameworkCore;
using VirtualGardenerServer.Infrastructure.Models;

namespace VirtualGardenerServer.Infrastructure.Database;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }

    //DbSets here

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}