using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Database;

public class ConnectionContext : DbContext
{
    public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) {}
    
    public DbSet<UsersModel> Users { get; set;}
    public DbSet<MoviesModel> Movies { get; set;}
    
    public DbSet<RoomsModel> Rooms { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UsersModel>().HasKey(u => u.IdUser);
        modelBuilder.Entity<MoviesModel>().HasKey(u => u.IdMovie);
        modelBuilder.Entity<RoomsModel>().HasKey(u => u.IdRoom);
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.IdUser).IsUnique().HasDatabaseName("pk_user");
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.Username).IsUnique().HasDatabaseName("username");
        modelBuilder.Entity<UsersModel>().Property(u => u.Role).HasConversion<int>();
    }
}