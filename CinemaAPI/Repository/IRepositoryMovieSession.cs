using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryMovieSession
{
    public void AddMovieSession(MovieSessionModel movieSession);

    public List<ViewSessionDto> GetAllSessions();
    public List<ViewSessionDto> GetActiveSessions();
}