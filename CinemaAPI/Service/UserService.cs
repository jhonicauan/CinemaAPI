using CinemaAPI.Database;
using CinemaAPI.DTO;
using CinemaAPI.Enums;
using CinemaAPI.Error;
using CinemaAPI.Model;
using CinemaAPI.Repository;
using CinemaAPI.Utility;

namespace CinemaAPI.Service;


public class UserService
{
    private readonly IRepositoryUsers _repositoryUsers;
    private readonly ConnectionContext _context;

    public UserService(IRepositoryUsers repositoryUsers, ConnectionContext context)
    {
        _repositoryUsers = repositoryUsers;
        _context = context;
    }

    public void AddUser(AddUsersDto usersDto)
    {
        string username = usersDto.Username;
        string password = usersDto.Password;
        
        if (!ValidatePassword(password))
        {
            throw new MinLengthException("Senhas devem ter no mínimo 8 caracteres");
        }

        if (UserExists(username))
        {
            throw new InvalidUniqueException("Usuario já existe");
        }
        
        string name = usersDto.Name;
        string hashPassword = PasswordCrypt.CryptPassword(password);
        UserRoles role = usersDto.Role;
        
        UsersModel user = new UsersModel(name,username,hashPassword,role);

        _repositoryUsers.AddUser(user);

    }

    public bool LoginIsCorrect(LoginDto loginDto)
    {
        string username = loginDto.username;
        string password = loginDto.password;

        if (!UserExists(username))
        {
            return false;
        }

        string hashPassword = _context.Users.Where(u => u.Username == username).Select(u => u.Password).First();
        
        return PasswordCrypt.ValidatePassword(password, hashPassword);
    }

    public List<ViewUsersDto> GetUsers()
    {
        return _repositoryUsers.GetUsers();
    }

    private bool ValidatePassword(string password)
    {
        return password.Length >= 8;
    }

    public UserRoles GetRole(string username)
    {
        return _context.Users.Where(u => u.Username == username).Select(u => u.Role).First();
    }

    private bool UserExists(string username)
    {
        return _context.Users.Any(u => u.Username == username);
    }
    
}