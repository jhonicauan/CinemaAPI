using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Model;

[Table("Users")]
public class UsersModel
{
    [Key]
    [Column("IdUser")]
    public int IdUser { get; private set; }
    [MaxLength(50)]
    [Column("Username")]
    public string Username { get; private set; }
    [MaxLength(50)]
    [Column("Password")]
    public string Password { get; private set; }
}