using Microsoft.EntityFrameworkCore;

namespace VirtualGardenerServer.Infrastructure.Database;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //DbSets here

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}