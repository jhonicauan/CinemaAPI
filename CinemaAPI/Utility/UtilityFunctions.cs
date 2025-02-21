namespace CinemaAPI.Utility;

public class UtilityFunctions
{
    public static string Capitalize(string text)
    {
        return char.ToUpper(text[0]) + text.Substring(1);
    }
}