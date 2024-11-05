namespace Api1.Models;

using System.Text.Json.Serialization;


public class Page<T>
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous{ get; set; }
    public List<T> Result { get; set; }
}

public class Planet
{

    // JSON serializar/deserialzer  -> PascalCase x / camelCase / snake_case


    public string Name { get; set; } = "";
    public string Diameter { get; set; } = "";

    [JsonPropertyName("rotation_period")]
    public string RotationPeriod { get; set; } = "";
    [JsonPropertyName("orbital_period")]
    public string OrbitalPeriod { get; set; } = "";
    public string Gravity { get; set; } = "";
    public string Population { get; set; } = "";
    public string Climate { get; set; } = "";
    public string Terrain { get; set; } = "";
    [JsonPropertyName("surface_water")]
    public string SurfaceWater { get; set; } = "";
    public List<string> Residents { get; set; } = [];
    public List<string> Films { get; set; } = [];
    public string Url { get; set; } = "";

    public string Created { get; set; } = "";

    public string Edited { get; set; } = "";


}
