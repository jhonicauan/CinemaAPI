using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Error;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using CinemaAPI.Utility;

namespace CinemaAPI.Service;

public class CategoryService
{
    
    private readonly ConnectionContext _context;
    private readonly IRepositoryCategory _repository;

    public CategoryService(ConnectionContext context, IRepositoryCategory repository)
    {
        _context = context;
        _repository = repository;
    }
    
    
    public bool CategoryExists(string name)
    {
        return _context.Category.Any(c => c.Name == name);
    }

    public void AddCategory(CategoryDto categoryDto)
    {
        string name = categoryDto.Name;

        name = name.ToLower();
        name = UtilityFunctions.Capitalize(name);
        if (CategoryExists(name))
        {
            throw new InvalidUniqueException("Esta categoria já existe.");
        }

        CategoryModel category = new CategoryModel(name);
        
        _repository.AddCategory(category);
    }

    public List<CategoryDto> GetAllCategories()
    {
        return _repository.GetAllCategories();
    }
    
    
}