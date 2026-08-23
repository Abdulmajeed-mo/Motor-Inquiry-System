namespace Motor.Inquiry.Domain.Exceptions;


public class VehicleNotFoundException : Exception
{
    //المركبة غير موجودة
    //404 Not Found
    public VehicleNotFoundException(string message)
        : base(message)
    {
    }
}