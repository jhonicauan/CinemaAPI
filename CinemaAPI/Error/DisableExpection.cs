namespace CinemaAPI.Error;

public class DisableExpection : Exception
{
    public DisableExpection(string message) : base(message){}
}