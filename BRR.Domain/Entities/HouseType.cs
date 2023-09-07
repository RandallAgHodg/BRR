namespace BRR.Domain.Entities;

public sealed class HouseType
{
    private HouseType()
    {
        
    }
    public HouseType(int id, string name)
    {
        Id = id;

        Name = name;
    }

    public static HouseType[] PopulateDatabase() => new[]
        {
            new HouseType(1, "venta"),
            new HouseType(2, "alquiler")
        };
    public int Id { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<House> Houses { get; set; }
}
