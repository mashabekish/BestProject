namespace WebApp.Exceptions;

public class InvalidParamsException : Exception
{
    public InvalidParamsException(string? message)
        : base(message) { }
}
