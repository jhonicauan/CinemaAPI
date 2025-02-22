using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Enums;
using CinemaAPI.Error;
using CinemaAPI.Model;
using CinemaAPI.Repository;

namespace CinemaAPI.Service;

public class TicketService
{
    private readonly ConnectionContext _context;
    private readonly IRepositoryTicket _repository;

    public TicketService(ConnectionContext context, IRepositoryTicket repository)
    {
        _context = context;
        _repository = repository;
    }

    public void AddTicket(AddTicketDto ticketDto)
    {
        int idSession = ticketDto.IdSession;
        int idSeat = ticketDto.IdSeat;
        int idUser = ticketDto.IdUser;
        TypeTicket typeTicket = ticketDto.TypeTicket;
        if (!SessionIsValid(idSession))
        {
            throw new InvalidDataException("Esta sessão não esta mais disponivel");
        }

        if (!SeatIsValid(idSeat, idSession))
        {
            throw new InvalidUniqueException("Este lugar já tem um dono.");
        }
        
        TicketModel ticket = new TicketModel(idSeat,idUser,idSession,typeTicket);

        _repository.AddTicket(ticket);
    }

    public List<ViewTicketDto> ViewAllMyTickets(int userId)
    {
        return _repository.ViewAllMyTickets(userId);
    }

    public List<ViewTicketDto> ViewMyActiveTickets(int userId)
    {
        return _repository.ViewMyActiveTickets(userId);
    }

    private bool SessionIsValid(int sessionId)
    {
        return _context.MovieSession.Find(sessionId).SessionDate >= DateTime.UtcNow;
    }

    private bool SeatIsValid(int seatId,int sessionId)
    {
        return _context.Ticket.Count(t => t.IdSeat == seatId && t.IdMovieSession == sessionId) == 0;
    }
}