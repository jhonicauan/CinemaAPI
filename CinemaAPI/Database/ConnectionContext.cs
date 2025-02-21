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
    
    public DbSet<SeatsModel> Seats { get; set;}
    
    public DbSet<MovieSessionModel> MovieSession { get; set;}
    
    public DbSet<TicketModel> Ticket { get; set;}
    
    public DbSet<MovieCategoryModel> MovieCategory { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Keys
        modelBuilder.Entity<UsersModel>().HasKey(u => u.IdUser);
        modelBuilder.Entity<MoviesModel>().HasKey(u => u.IdMovie);
        modelBuilder.Entity<RoomsModel>().HasKey(r => r.IdRoom);
        modelBuilder.Entity<CategoryModel>().HasKey(u => u.IdCategory);
        modelBuilder.Entity<MovieCategoryModel>().HasKey(mc => new { mc.IdMovie,mc.IdCategory });
        modelBuilder.Entity<SeatsModel>().HasKey(s => new { s.IdSeat});
        modelBuilder.Entity<MovieSessionModel>().HasKey(ms => new { ms.IdMovieSession});
        modelBuilder.Entity<TicketModel>().HasKey(t => new { t.IdTicket});
        //Foreign Keys
        modelBuilder.Entity<MovieCategoryModel>().HasOne(mc => mc.Movies).WithMany(m => m.MovieCategories).HasForeignKey(mc => mc.IdMovie);
        modelBuilder.Entity<MovieCategoryModel>().HasOne(mc => mc.Category).WithMany(c => c.MovieCategories).HasForeignKey(mc => mc.IdCategory);
        modelBuilder.Entity<SeatsModel>().HasOne(s => s.Room).WithMany(r => r.Seats).HasForeignKey(s => s.IdRoom);
        modelBuilder.Entity<MovieSessionModel>().HasOne(ms => ms.Movie).WithMany(m => m.MovieSessions).HasForeignKey(ms => ms.IdMovie);
        modelBuilder.Entity<MovieSessionModel>().HasOne(ms => ms.Room).WithMany(r => r.MovieSessions).HasForeignKey(ms => ms.IdRoom);
        modelBuilder.Entity<TicketModel>().HasOne(t => t.Seat).WithMany(s => s.Tickets).HasForeignKey(t => t.IdSeat);
        modelBuilder.Entity<TicketModel>().HasOne(t => t.MovieSession).WithMany(ms => ms.Tickets).HasForeignKey(t => t.IdMovieSession);
        modelBuilder.Entity<TicketModel>().HasOne(t => t.Users).WithMany(u => u.Tickets).HasForeignKey(t => t.IdUser);
        //Index
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.IdUser).IsUnique().HasDatabaseName("pk_user");
        modelBuilder.Entity<UsersModel>().HasIndex(u => u.Username).IsUnique().HasDatabaseName("username");
        
        //Propertys
        modelBuilder.Entity<UsersModel>().Property(u => u.Role).HasConversion<int>();
        modelBuilder.Entity<SeatsModel>().Property(s => s.TypeSeat).HasConversion<int>();
        modelBuilder.Entity<TicketModel>().Property(s => s.TypeTicket).HasConversion<int>();
    }
}