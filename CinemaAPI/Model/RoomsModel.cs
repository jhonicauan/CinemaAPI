using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("Rooms")]
public class RoomsModel
{
    [Key]
    public int IdRoom { get; private set; }
    
    public string Name { get; set; }

    public RoomsModel()
    {
        Name = "Sala ";
    }
    
}