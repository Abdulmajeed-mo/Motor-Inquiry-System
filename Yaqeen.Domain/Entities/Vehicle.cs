using System.ComponentModel.DataAnnotations;

namespace Yaqeen.Domain.Entities;

public class Vehicle
{
    [Key]
    public int SequenceNumber { get; set; }

    public string PlateNumber { get; set; }

    public string PlateLetters { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int ModelYear { get; set; }

    public string Color { get; set; }

    public string ChassisNumber { get; set; }

    public string OwnerNationalId { get; set; }
}