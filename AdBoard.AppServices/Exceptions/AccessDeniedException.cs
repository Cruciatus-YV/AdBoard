namespace AdBoard.AppServices.Exceptions;

public class AccessDeniedException : HumanReadableException
{
    public AccessDeniedException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public AccessDeniedException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}
