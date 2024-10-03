namespace AdBoard.AppServices.Exceptions;

public class NoneMeasurementUnitException : HumanReadableException
{
    public NoneMeasurementUnitException(string humanReadableMessage) : base(humanReadableMessage)
    {
    }

    public NoneMeasurementUnitException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
    {
    }
}
