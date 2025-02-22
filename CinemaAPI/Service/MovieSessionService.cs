using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Error;
using CinemaAPI.Model;
using CinemaAPI.Repository;

namespace CinemaAPI.Service;

public class MovieSessionService
{
    private readonly IRepositoryMovieSession _repository;
    private readonly ConnectionContext _context;

    public MovieSessionService(IRepositoryMovieSession repository, ConnectionContext context)
    {
        _repository = repository;
        _context = context;
    }

    public void AddMovieSession(AddSessionDto movieSessionDto)
    {
        if (!SessionDateIsValid(movieSessionDto.SessionDate))
        {
            throw new InvalidDataException("Sessão não pode ser em datas já passadas");
        }

        if (!MovieIsValid(movieSessionDto.IdMovie))
        {
            throw new DisableExpection("Este filme não esta mais em cartaz");
        }
        MovieSessionModel movieSession = new MovieSessionModel(movieSessionDto.IdMovie,movieSessionDto.IdRoom,movieSessionDto.SessionDate);
        _repository.AddMovieSession(movieSession);
    }

    public List<ViewSessionDto> GetAllSessions()
    {
        return _repository.GetAllSessions();
    }

    public List<ViewSessionDto> GetActiveSessions()
    {
        return _repository.GetActiveSessions();
    }

    private bool SessionDateIsValid(DateTime sessionDate)
    {
        return sessionDate <= DateTime.UtcNow;
    }

    private bool MovieIsValid(int movieId)
    {
        return _context.Movies.Find(movieId).Active;
    }
}