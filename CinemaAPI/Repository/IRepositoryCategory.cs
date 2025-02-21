using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryCategory
{
    public void AddCategory(CategoryModel category);

    public List<CategoryDto> GetAllCategories();
}