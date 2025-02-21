namespace CinemaAPI.Model;

public class MovieSessionModel
{
    public int IdMovieSession { get; private set; }
    public int IdMovie { get; private set; }
    public MoviesModel Movie { get; private set; } 
    public int IdRoom { get; private set; }
    public RoomsModel Room { get; private set; } 
    public DateTime SessionDate { get;  set; }
    
    public List<TicketModel> Tickets { get; set; } = new();

    public MovieSessionModel(int idMovie, int idRoom, DateTime sessionDate)
    {
        IdMovieSession = idMovie;
        IdRoom = idRoom;
        SessionDate = sessionDate;
    }
    
    public MovieSessionModel(){}
}