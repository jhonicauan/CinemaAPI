namespace CinemaAPI.Error;

public class MinLengthException : Exception
{
    public MinLengthException(string message) : base(message){}
}