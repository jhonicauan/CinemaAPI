using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public class MovieRepository : IRepositoryMovie
{
    private readonly ConnectionContext _context;

    public MovieRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddMovie(MoviesModel movie)
    {
        _context.Add(movie);
        _context.SaveChanges();
    }

    public void ChangeStatusMovie(int movieId)
    {
        MoviesModel movie = _context.Movies.Find(movieId) ?? throw new InvalidOperationException();
        if (movie.Active)
        {
            movie.Active = false;
        }
        else
        {
            movie.Active = true;
        }
        _context.Update(movie);
        _context.SaveChanges();
    }

    public List<MovieDto> GetAllMovies()
    {
        return _context.Movies
            .Select(m => new MovieDto(
                m.Name,
                m.Description,
                m.ImageUrl)).ToList();
    }

    public List<MovieDto> GetActiveMovies()
    {
        return _context.Movies
            .Where(m => m.Active)
            .Select(m => new MovieDto(
                m.Name,
                m.Description,
                m.ImageUrl)).ToList();
    }

    public List<MovieDto> FindMovies(string search)
    {
        return _context.Movies
            .Where(m => m.Active && m.Name.Contains(search))
            .Select(m => new MovieDto(
                m.Name,
                m.Description,
                m.ImageUrl)).ToList();
    }
}