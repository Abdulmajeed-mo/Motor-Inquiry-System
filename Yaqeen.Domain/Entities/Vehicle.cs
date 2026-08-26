using System.ComponentModel.DataAnnotations;

namespace Yaqeen.Domain.Entities;

public class Vehicle
{
    [Key]
    public int SequenceNumber { get; set; }

    public string PlateNumber { get; set; } = string.Empty;

    public string PlateLetters { get; set; } = string.Empty;

    public int MakeId { get; set; }

    public Make Make { get; set; } = null!;

    public int ModelId { get; set; }

    public Model Model { get; set; } = null!;

    public int ModelYear { get; set; }

    public string Color { get; set; } = string.Empty;

    public string ChassisNumber { get; set; } = string.Empty;

    public string OwnerNationalId { get; set; } = string.Empty;
}