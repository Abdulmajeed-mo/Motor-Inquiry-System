namespace Yaqeen.Application.DTOs;

public class CitizenAddressResponse
{
    public string NationalId { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public List<string> Addresses { get; set; } = new();
}