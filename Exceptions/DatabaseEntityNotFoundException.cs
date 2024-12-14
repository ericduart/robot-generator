namespace robot_generator.Exceptions;

public class DatabaseEntityNotFoundException : Exception
{
    public DatabaseEntityNotFoundException()
    {
        
    }

    public DatabaseEntityNotFoundException(string message) : base(message)
    {
    }

    public DatabaseEntityNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}