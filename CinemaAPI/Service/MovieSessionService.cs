using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Repository;

namespace CinemaAPI.Service;

public class MovieSessionService
{
    private readonly IRepositoryMovieSession _repository;

    public MovieSessionService(IRepositoryMovieSession repository)
    {
        _repository = repository;
    }

    public void AddMovieSession(AddSessionDto movieSessionDto)
    {
        if (movieSessionDto.SessionDate <= DateTime.Now)
        {
            throw new InvalidDataException("Sessão não pode ser em datas já passadas");
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
}