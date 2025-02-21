using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repository;

public class MovieSessionRepository : IRepositoryMovieSession
{
    private readonly ConnectionContext _context;

    public MovieSessionRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddMovieSession(MovieSessionModel movieSession)
    {
        _context.Add(movieSession);
        _context.SaveChanges();
    }

    public List<ViewSessionDto> GetAllSessions()
    {
        return _context.MovieSession
            .Include(ms => ms.Movie)
            .ThenInclude(m => m.MovieSessions)
            .ThenInclude(ms => ms.Room)
            .Select(ms => new ViewSessionDto(ms.Movie.Name, ms.Room.Name, ms.SessionDate))
            .ToList();
    }
    
    public List<ViewSessionDto> GetActiveSessions()
    {
        return _context.MovieSession
            .Include(ms => ms.Movie)
            .ThenInclude(m => m.MovieSessions)
            .ThenInclude(ms => ms.Room)
            .Where(ms => ms.SessionDate >= DateTime.UtcNow)
            .Select(ms => new ViewSessionDto(ms.Movie.Name, ms.Room.Name, ms.SessionDate))
            .ToList();
    }
}