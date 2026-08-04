namespace Motor.Inquiry.Domain.Exceptions;

public class OwnershipMismatchException : Exception
{
    public OwnershipMismatchException(string message): base(message)
    {
    }
}