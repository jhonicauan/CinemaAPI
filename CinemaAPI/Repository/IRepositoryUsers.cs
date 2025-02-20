using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public interface IRepositoryUsers
{
    public void AddUser(UsersModel user);
    public List<ViewUsersDto> GetUsers();
}