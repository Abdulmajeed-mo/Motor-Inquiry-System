namespace Yaqeen.Domain.Entities;

public class Address
{
    public int Id { get; set; }

    public string AddressLine { get; set; } = string.Empty;

    public string CitizenId { get; set; } = string.Empty;
    public Citizen Citizen { get; set; } = null!;
}