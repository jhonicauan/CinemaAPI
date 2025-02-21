using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public class CategoryRepository : IRepositoryCategory
{
    private readonly ConnectionContext _context;

    public CategoryRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddCategory(CategoryModel category)
    {
        _context.Add(category);
        _context.SaveChanges();
    }

    public List<CategoryDto> GetAllCategories()
    {
        return _context.Category.Select(c => new CategoryDto(c.Name)).ToList();
    }
}