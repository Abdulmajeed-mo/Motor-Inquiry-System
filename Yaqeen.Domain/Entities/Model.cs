namespace Yaqeen.Domain.Entities;

public class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int MakeId { get; set; }

    public Make Make { get; set; } = null!;

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}