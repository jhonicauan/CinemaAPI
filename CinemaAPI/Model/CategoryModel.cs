using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("Categories")]
public class CategoryModel
{
    [Key]
    public int IdCategory { get; private set; }
    [MaxLength(80)]
    public string Name { get;set; }
    public List<MovieCategoryModel> MovieCategories { get; set; } = new();

    public CategoryModel()
    {
    }

    public CategoryModel(int id, string name)
    {
        IdCategory = id;
        Name = name;
    }

    public CategoryModel(string name)
    {
        Name = name;
    }
}