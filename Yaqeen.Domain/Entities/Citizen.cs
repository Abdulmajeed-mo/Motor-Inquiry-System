using System.ComponentModel.DataAnnotations;
using Yaqeen.Domain.Enums;

namespace Yaqeen.Domain.Entities;

public class Citizen
{
    [Key]
    public string NationalId { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string FullName { get; set; }

    public Gender Gender { get; set; }

    public string Nationality { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}