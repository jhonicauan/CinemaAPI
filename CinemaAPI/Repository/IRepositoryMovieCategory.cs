using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryMovieCategory
{
    public void AddMovieCategory(MovieCategoryModel movieCategory);

    public List<MovieCategoryDto> GetMoviesByCategory(int idCategory);}