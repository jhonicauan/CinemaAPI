using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryMovie
{
    public void AddMovie(MoviesModel movie);
    public void ChangeStatusMovie(int movieId);
    public List<MovieDto> GetAllMovies();
    public List<MovieDto> GetActiveMovies();
    public List<MovieDto> FindMovies(string search);
}