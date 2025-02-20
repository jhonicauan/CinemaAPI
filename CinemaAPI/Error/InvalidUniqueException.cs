namespace CinemaAPI.Error;

public class InvalidUniqueException : Exception
{
    public InvalidUniqueException(string message) : base(message){}
}