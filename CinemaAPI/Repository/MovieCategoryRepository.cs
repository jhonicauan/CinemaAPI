using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Repository;

public class MovieCategoryRepository : IRepositoryMovieCategory
{
    private readonly ConnectionContext _context;

    public MovieCategoryRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddMovieCategory(MovieCategoryModel movieCategory)
    {
        _context.Add(movieCategory);
        _context.SaveChanges();
    }

    public List<MovieCategoryDto> GetMoviesByCategory(int idCategory)
    {
        return _context.MovieCategory.Where(mc => mc.IdCategory == idCategory)
            .Include(mc => mc.Movies)
            .ThenInclude(mc => mc.MovieCategories)
            .ThenInclude(mc => mc.Category)
            .Select(mc => new MovieCategoryDto(mc.Movies.Name, mc.Category.Name)).ToList();
    }
}