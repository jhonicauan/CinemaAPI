using CinemaAPI.DTO;

namespace CinemaAPI.Repository;

public interface IRepositoryUsers
{
    public void AddUsers(AddUsersDto user);
    public List<ViewUsersDto> GetUsers();
}