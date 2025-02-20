using CinemaAPI.DTO;
using CinemaAPI.Model;
using CinemaAPI.Repository;

namespace CinemaAPI.Database;

public class UsersRepository : IRepositoryUsers
{
    private ConnectionContext _context;

    public UsersRepository(ConnectionContext context)
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
        return _context.Users.Select(u => new ViewUsersDto(u.Name,u.Username)).ToList();
    }
}