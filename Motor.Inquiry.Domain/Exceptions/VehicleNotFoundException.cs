namespace Motor.Inquiry.Domain.Exceptions;

public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException(string message)
        : base(message)
    {
    }
}