namespace AdBoard.AppServices.Exceptions;

/// <summary>
/// Ошибка "Сущность не была найдена".
/// </summary>
public class NotFoundException : HumanReadableException
{
    public NotFoundException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public NotFoundException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}
