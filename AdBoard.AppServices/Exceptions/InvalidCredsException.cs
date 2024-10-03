namespace AdBoard.AppServices.Exceptions
{
    public class InvalidCredsException : HumanReadableException
    {
        public InvalidCredsException(string humanReadableMessage) : base(humanReadableMessage)
        {
        }

        public InvalidCredsException(string message, string humanReadableMessage) : base(message, humanReadableMessage)
        {
        }
    }
}
