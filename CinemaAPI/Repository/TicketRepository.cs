using CinemaAPI.Database;

namespace CinemaAPI.Repository;

public class TicketRepository : IRepositoryTicket
{
    private readonly ConnectionContext _context;

    public TicketRepository(ConnectionContext context)
    {
        _context = context;
    }
}