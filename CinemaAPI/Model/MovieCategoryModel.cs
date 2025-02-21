using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("MovieCategories")]
public class MovieCategoryModel
{
    public int IdMovie{get;private set;}
    public MoviesModel Movies { get; private set; }
    public int IdCategory{get;private set;}
    public CategoryModel Category { get; private set; }

    public MovieCategoryModel(int idMovie, int idCategory)
    {
        IdMovie = idMovie;
        IdCategory = idCategory;
    }
    
    public MovieCategoryModel() {}
}