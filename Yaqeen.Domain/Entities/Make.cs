namespace Yaqeen.Domain.Entities;

public class Make
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Model> Models { get; set; } = new List<Model>();

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}