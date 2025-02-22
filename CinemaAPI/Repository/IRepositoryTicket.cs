using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryTicket
{
    

    public void AddTicket(TicketModel ticket);

    public List<ViewTicketDto> ViewAllMyTickets(int userId);

    public List<ViewTicketDto> ViewMyActiveTickets(int userId);

}