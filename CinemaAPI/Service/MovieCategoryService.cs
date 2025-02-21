using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Error;
using CinemaAPI.Model;
using CinemaAPI.Repository;

namespace CinemaAPI.Service;

public class MovieCategoryService
{
    private readonly IRepositoryMovieCategory _repository;
    private readonly ConnectionContext _context;

    public MovieCategoryService(IRepositoryMovieCategory repository, ConnectionContext context)
    {
        _repository = repository;
        _context = context;
    }

    public void AddMovieCategory(AddMovieCategoryDto movieCategoryDto)
    {
        if (MovieCategoryExists(movieCategoryDto))
        {
            throw new InvalidUniqueException("Este filme já tem esta categoria.");
        }
        
        MovieCategoryModel movieCategory = new MovieCategoryModel(movieCategoryDto.IdMovie,movieCategoryDto.IdCategory);
        _repository.AddMovieCategory(movieCategory);
    }

    public List<MovieCategoryDto> GetMoviesByCategory(int idCategory)
    {
        return _repository.GetMoviesByCategory(idCategory);
    }

    public bool MovieCategoryExists(AddMovieCategoryDto movieCategory)
    {
        return _context.MovieCategory.Any(mc => mc.IdCategory == movieCategory.IdCategory && mc.IdMovie == movieCategory.IdMovie);
    }
}