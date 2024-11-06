namespace Api1.Services;

using System.ComponentModel;
using System.Net;
using System.Text.Json;
using Api1.Converters;
using Api1.Models;
using Microsoft.Extensions.Configuration;

public interface IPlanetService
{
    public Task<List<Planet>> GetPlanets();  // list  task async
    public Planet? GetPlanetById(int id);
}

public class PlanetService : IPlanetService
{
    private IConfiguration _config;
    private string _baseApiUrl = "";

    static readonly HttpClient client = new HttpClient();


    public PlanetService(IConfiguration config)
    {
        _config = config;
        _baseApiUrl = config.GetValue<string>("StarWarsAPI:BaseApi") ?? "";
    }


    //  GET https://swapi.dev/api/planets/{id}/
    public Planet? GetPlanetById(int id)
    {
        return null;
    }

    //  HTTP GET https://swapi.dev/api/planets/
    public async Task<List<Planet>> GetPlanets()
    {
        try
        {

            var url = $"{_baseApiUrl}/planets";
            using (var response = await client.GetAsync(url))  // launch ----------- ?? ms ---- response
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var options = new JsonSerializerOptions
                    {
                       PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                       PropertyNameCaseInsensitive = true,
                       Converters = {
                            new DateTimeJsonConverter(),
                            new IntJsonConverter()
                       }
                    };

                    var page = JsonSerializer.Deserialize<Page<Planet>>(response.Content.ReadAsStream(), options);
                    return page.Results;

                    // Debugging version
                    //// 200 ok
                    //foreach (var header in response.Content.Headers)
                    //{
                    //    var values = string.Join(", ", header.Value);

                    //    Console.WriteLine($"{header.Key} = {values}");
                    //}
                    //using (var reader = new StreamReader(response.Content.ReadAsStream()))
                    //{
                    //    var text = reader.ReadToEnd();
                    //    Console.WriteLine(text);
                    //}

                }
                else
                {
                    // error handling
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        return [];
    }
}
