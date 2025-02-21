using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("Movies")]
public class MoviesModel
{
    [Key]
    [Column("IdMovie")]
    public int IdMovie { get; private set;}
    
    [MaxLength(100)]
    [Column("Name")]
    public string Name { get; set;}
    
    [MaxLength(500)]
    [Column("Description")]
    public string Description { get; set;}
    
    [MaxLength(150)]
    [Column("ImageUrl")]
    public string ImageUrl { get; set;}
    
    [Column("Active")]
    public bool Active { get; set;}
    
    public MoviesModel(){}

    public MoviesModel(int id, string name, string description, string imageUrl)
    {
        IdMovie = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Active = true;
    }

    public MoviesModel(string name, string description, string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Active = true;
    }
}
