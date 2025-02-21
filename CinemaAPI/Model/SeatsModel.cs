using CinemaAPI.Enums;

namespace CinemaAPI.Model;

public class SeatsModel
{
    public int IdSeat { get; private set;}
    public int IdRoom { get; private set;}
    public RoomsModel Room { get; private set; } = new();
    public string RowLetter { get; set;}
    public int SeatNumber { get; set;}
    public TypeSeats TypeSeat { get; private set;}
    
    public List<TicketModel> Tickets { get; set; } = new();

    public SeatsModel(int idRoom,string rowLetter,int seatNumber, TypeSeats typeSeat)
    {
        IdRoom = idRoom;
        RowLetter = rowLetter;
        SeatNumber = seatNumber;
        TypeSeat = typeSeat;
    }
    
    public SeatsModel(){}
}