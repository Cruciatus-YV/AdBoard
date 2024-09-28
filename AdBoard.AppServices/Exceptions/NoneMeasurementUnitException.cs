namespace AdBoard.AppServices.Exceptions;

public class NoneMeasurementUnitException : Exception
{
    public NoneMeasurementUnitException() : base("Не указана единица измерения количества товара")
    {

    }
}
