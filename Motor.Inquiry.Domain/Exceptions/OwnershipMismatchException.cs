namespace Motor.Inquiry.Domain.Exceptions;


public class OwnershipMismatchException : Exception
{
    //المركبة ليست مملوكة للمواطن
    //403 Forbidden
    public OwnershipMismatchException(string message): base(message)
    {
    }
}