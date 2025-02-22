using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repository;

public class TicketRepository : IRepositoryTicket
{
    private readonly ConnectionContext _context;

    public TicketRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddTicket(TicketModel ticket)
    {
        _context.Add(ticket);
        _context.SaveChanges();
    }

    public List<ViewTicketDto> ViewAllMyTickets(int userId)
    {
        return _context.Ticket
            .Include(t => t.MovieSession)
            .ThenInclude(ms => ms.Movie)
            .Include(t => t.Seat)
            .ThenInclude(s => s.Room)
            .Include(t => t.Users)
            .Where(t => t.Users.IdUser == userId)
            .Select(t => new ViewTicketDto(
                t.Users.Name,
                t.Seat.Room.Name,
                t.Seat.RowLetter,
                t.Seat.SeatNumber,
                t.MovieSession.Movie.Name,
                t.MovieSession.SessionDate
            )).ToList();
    }
    
    public List<ViewTicketDto> ViewMyActiveTickets(int userId)
    {
        return _context.Ticket
            .Include(t => t.MovieSession)
            .ThenInclude(ms => ms.Movie)
            .Include(t => t.Seat)
            .ThenInclude(s => s.Room)
            .Include(t => t.Users)
            .Where(t => t.Users.IdUser == userId && t.MovieSession.SessionDate >= DateTime.UtcNow)
            .Select(t => new ViewTicketDto(
                t.Users.Name,
                t.Seat.Room.Name,
                t.Seat.RowLetter,
                t.Seat.SeatNumber,
                t.MovieSession.Movie.Name,
                t.MovieSession.SessionDate
            )).ToList();
    }
}