namespace AdBoard.AppServices.Exceptions;

/// <summary>
/// Ошибка "Сущности не были найдены"
/// </summary>
public class EntitiesNotFoundException : HumanReadableException
{
    public EntitiesNotFoundException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public EntitiesNotFoundException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}