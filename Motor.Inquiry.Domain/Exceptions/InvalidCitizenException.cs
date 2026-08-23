namespace Motor.Inquiry.Domain.Exceptions;


public class InvalidCitizenException : Exception
{

    //المواطن غير صالح
    //400 Bad Request
    public InvalidCitizenException(string message) : base(message)
    {


    }
}