using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryMovie
{
    public void AddMovie(MoviesModel movie);


    public List<MovieDto> GetAllMovies();
    public List<MovieDto> GetActiveMovies();
}