using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Database;

public class ConnectionContext : DbContext
{
    public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) {}
    
    public DbSet<UsersModel> Users { get; set;}
    public DbSet<MoviesModel> Movies { get; set;}
    
    public DbSet<RoomsModel> Rooms { get; set;}
    public DbSet<CategoryModel> Category { get; set;}
    
    public DbSet<MovieCategoryModel> MovieCategory { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Keys
        modelBuilder.Entity<UsersModel>().HasKey(u => u.IdUser);
        modelBuilder.Entity<MoviesModel>().HasKey(u => u.IdMovie);
        modelBuilder.Entity<RoomsModel>().HasKey(u => u.IdRoom);
        modelBuilder.Entity<CategoryModel>().HasKey(u => u.IdCategory);
        modelBuilder.Entity<MovieCategoryModel>().HasKey(mc => new { mc.IdMovie,mc.IdCategory });
        //Foreign Keys
        modelBuilder.Entity<MovieCategoryModel>().HasOne(mc => mc.Movies).WithMany(m => m.MovieCategories).HasForeignKey(mc => mc.IdMovie);
        modelBuilder.Entity<MovieCategoryModel>().HasOne(mc => mc.Category).WithMany(c => c.MovieCategories).HasForeignKey(mc => mc.IdCategory);
        //Index
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.IdUser).IsUnique().HasDatabaseName("pk_user");
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.Username).IsUnique().HasDatabaseName("username");
        
        //Propertys
        modelBuilder.Entity<UsersModel>().Property(u => u.Role).HasConversion<int>();
    }
}