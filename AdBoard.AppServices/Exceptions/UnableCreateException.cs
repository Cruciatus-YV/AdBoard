namespace AdBoard.AppServices.Exceptions;

public class UnableCreateException : HumanReadableException
{
    public UnableCreateException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public UnableCreateException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}
