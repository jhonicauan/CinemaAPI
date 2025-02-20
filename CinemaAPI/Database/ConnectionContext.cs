using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Database;

public class ConnectionContext : DbContext
{
    public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) {}
    
    public DbSet<UsersModel> Users { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UsersModel>().HasIndex(U => U.IdUser).IsUnique().HasDatabaseName("pk_users");
    }
}