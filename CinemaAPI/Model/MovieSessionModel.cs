namespace CinemaAPI.Model;

public class MovieSessionModel
{
    public int IdMovieSession { get; private set; }
    public int IdMovie { get; private set; }
    public MoviesModel Movie { get; private set; } = new();
    public int IdRoom { get; private set; }
    public RoomsModel Room { get; private set; } = new();
    public DateTime SeassonDate { get;  set; }
    
    public List<TicketModel> Tickets { get; set; } = new();

    public MovieSessionModel(int idMovie, int idRoom, DateTime seassonDate)
    {
        IdMovieSession = idMovie;
        IdRoom = idRoom;
        SeassonDate = seassonDate;
    }
    
    public MovieSessionModel(){}
}