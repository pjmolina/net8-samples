namespace Api2.Services;

using System.Net;
using System.Text.Json;
using Api2.Models;

public interface IPlanetService
{
    public Task<List<Planet>> GetPlanets();
    public Planet? GetPlanetById(int id);
}

public class PlanetService : IPlanetService
{
    private static HttpClient _http = new HttpClient();

    // const string BaseApiUrl = "https://swapi.dev/api";  // dev  qa  pro

    private string _baseApiUrl = "";


    public PlanetService(IConfiguration config)
    {
        _baseApiUrl = config.GetValue<string>("StarWarsAPI:BaseUrl") ?? "";      
    }

    // config
    //    const string  compile time
    //    conf file
    //    enviromental variable  (linux docker)
    //    conf db
    //    consul vault


    // GET https://swapi.dev/api/planets/{id}/
    public Planet? GetPlanetById(int id)
    {
        var url = $"{_baseApiUrl}/planets/{id}/";

        return null;
    }

    // GET https://swapi.dev/api/planets/
    public async Task<List<Planet>> GetPlanets()
    {
        var url = $"{_baseApiUrl}/planets/";

        var response = await _http.GetAsync(url);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };

            var page = JsonSerializer.Deserialize<Page<Planet>>(response.Content.ReadAsStream(), options);
            return page.Result;

            // Debug purpouse
            //foreach (var header in response.Headers)
            //{
            //    var values = string.Join(", ", header.Value);
            //    Console.WriteLine($"{header.Key} = {values}");
            //}
            //var payload = await response.Content.ReadAsStringAsync();
            //Console.WriteLine($"{payload}");

        }
        else
        {
            // Error
            Console.WriteLine($"{response.RequestMessage}");

        }
        // sync vs async
        //var task = System.IO.File.ReadAllTextAsync("film.mp4");  // 20 ms  thread   CPU  3Tb  30 s 90 s 

       



        return [];
    }
}
