using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("Rooms")]
public class RoomsModel
{
    [Key]
    public int IdRoom { get; private set; }
    
    public string Name { get; set; }

    public List<SeatsModel> Seats { get; set; } = new();
    public List<MovieSessionModel> MovieSessions { get; set; } = new();

    public RoomsModel()
    {
        Name = "Sala ";
    }
    
}