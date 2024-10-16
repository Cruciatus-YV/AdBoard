namespace AdBoard.AppServices.Exceptions;

public class EmailAlredyRegisteredException : HumanReadableException
{
    public EmailAlredyRegisteredException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public EmailAlredyRegisteredException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}