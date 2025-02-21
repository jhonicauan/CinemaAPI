using CinemaAPI.Database;

namespace CinemaAPI.Repository;

public class SeatRepository : IRepositorySeat
{
    private readonly ConnectionContext _context;

    public SeatRepository(ConnectionContext context)
    {
        _context = context;
    }
}