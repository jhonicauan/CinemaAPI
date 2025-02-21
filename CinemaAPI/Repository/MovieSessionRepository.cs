using CinemaAPI.Database;

namespace CinemaAPI.Repository;

public class MovieSessionRepository : IRepositoryMovieSession
{
    private readonly ConnectionContext _context;

    public MovieSessionRepository(ConnectionContext context)
    {
        _context = context;
    }
}