namespace Api1.Models;

using System.Text.Json.Serialization;


public class Page<T>
{
    public int Count { get; set; }
    public string? Next { get; set; }
    
    public string? Previous{ get; set; }
    public List<T> Results { get; set; }
}

public class Planet
{

    // JSON serializar/deserialzer  -> PascalCase x / camelCase / snake_case


    public string Name { get; set; } = "";
    public int Diameter { get; set; }

    //[JsonPropertyName("rotation_period")]
    public int RotationPeriod { get; set; }
    //[JsonPropertyName("orbital_period")]
    public int OrbitalPeriod { get; set; }
    public string Gravity { get; set; } = "";
    public int Population { get; set; }
    public string Climate { get; set; } = "";
    public string Terrain { get; set; } = "";
    //[JsonPropertyName("surface_water")]
    public int SurfaceWater { get; set; }
    public List<string> Residents { get; set; } = [];
    public List<string> Films { get; set; } = [];
    public string Url { get; set; } = "";

    public DateTime Created { get; set; }

    public DateTime Edited { get; set; }


}
