namespace Api2.Models;

using System.Text.Json.Serialization;
using Api2.Services;

public class Page<T>
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }

    public List<T> Results { get; set; } = [];
}

public class Planet
{
    public string Name { get; set; } = "";
    public long Diameter { get; set; }

    //[JsonPropertyName("rotation_period")]
    public long RotationPeriod { get; set; }
    //[JsonPropertyName("orbital_period")]
    public long OrbitalPeriod { get; set; }


    public string Gravity { get; set; } = "";
    public long Population { get; set; }
    public string Climate { get; set; } = "";
    public string Terrain { get; set; } = "";

    //[JsonPropertyName("surface_water")]
    public long SurfaceWater { get; set; }

    public List<string> Residents { get; set; } = [];
    public List<string> Films { get; set; } = [];
    public string Url { get; set; } = "";
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }


}
