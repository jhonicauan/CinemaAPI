namespace CinemaAPI.Utility;

public class PasswordCrypt
{
    public static string CryptPassword(string password)
    {
       return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool ValidatePassword(string password,string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}