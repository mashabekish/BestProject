namespace WebApp.Exceptions;

public class InvalidItemException : Exception
{
    public InvalidItemException(string? message = null)
        : base(message) { }
}
