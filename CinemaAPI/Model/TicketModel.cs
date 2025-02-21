using CinemaAPI.Enums;

namespace CinemaAPI.Model;

public class TicketModel
{
    public int IdTicket { get; private set;}
    public int IdSeat { get; private set;}
    public SeatsModel Seat { get; private set; } = new();
    public int IdUser { get; private set;}
    public UsersModel Users { get; private set;} = new();
    public int IdMovieSession { get; private set;}
    public MovieSessionModel MovieSession { get; private set;} = new();

    private float price { get; set; }
    public TypeTicket TypeTicket { get; private set;}
    
    public TicketModel(){}

    public TicketModel(int idSeat, int idUser, int idMovieSession, TypeTicket typeTicket)
    {
        IdSeat = idSeat;
        IdUser = idUser;
        IdMovieSession = idMovieSession;
        TypeTicket = typeTicket;
        if (TypeTicket == TypeTicket.Normal)
        {
            price = 25;
        }
        else
        {
            price = 12.5f;
        }
    }
    
}