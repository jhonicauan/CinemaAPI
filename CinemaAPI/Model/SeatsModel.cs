using CinemaAPI.Enums;

namespace CinemaAPI.Model;

public class SeatsModel
{
    public int IdSeat { get; private set;}
    public int IdRoom { get; private set;}
    public RoomsModel Room { get; private set; }
    public string RowLetter { get; set;}
    public int SeatNumber { get; set;}
    public TypeSeats TypeSeat { get; set;}
    
    public List<TicketModel> Tickets { get; set; } 

    public SeatsModel(int idRoom,string rowLetter,int seatNumber)
    {
        IdRoom = idRoom;
        RowLetter = rowLetter;
        SeatNumber = seatNumber;
        TypeSeat = TypeSeats.Normal;
    }
    
    public SeatsModel(){}
}