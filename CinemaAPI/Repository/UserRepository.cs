using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Model;

namespace CinemaAPI.Repository;

public class UserRepository: IRepositoryUsers
{
    private readonly ConnectionContext _context;

    public UserRepository(ConnectionContext context)
    {
        _context = context;
    }

    public void AddUser(UsersModel user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public List<ViewUsersDto> GetUsers()
    {
        return _context.Users.Select(u => new ViewUsersDto(u.Name, u.Username)).ToList();
    }
}