using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinemaAPI.Enums;

namespace CinemaAPI.Model;

[Table("Users")]
public class UsersModel
{
    [Key]
    [Column("IdUser")]
    public int IdUser { get;}
    
    [MaxLength(80)]
    [Column("Name")]
    public string Name { get; private set; }
    
    [MaxLength(50)]
    [Column("Username")]
    public string Username { get; private set; }
    
    [MaxLength(50)]
    [Column("Password")]
    public string Password { get; private set; }
    
    [Column("Role")]
    public UserRoles Role {get;}
    
    public UsersModel() {}

    public UsersModel(string name, string username, string password, UserRoles role)
    {
        Name = name;
        Username = username;
        Password = password;
        Role = role;
    }
}