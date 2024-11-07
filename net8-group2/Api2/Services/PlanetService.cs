namespace Api2.Services;

using System.Net;
using System.Text.Json;
using Api2.Converters;
using Api2.Models;
using Microsoft.Extensions.Options;

public interface IPlanetService
{
    public Task<List<Planet>> GetPlanets();
    public Task<Planet?> GetPlanetById(int id);
}

public class PlanetService : IPlanetService
{
    private static HttpClient _http = new HttpClient();

    // const string BaseApiUrl = "https://swapi.dev/api";  // dev  qa  pro

    private string _baseApiUrl = "";

    private JsonSerializerOptions _jsonOptions;


    public PlanetService(IConfiguration config)
    {
        _baseApiUrl = config.GetValue<string>("StarWarsAPI:BaseUrl") ?? "";
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters =
                {
                    new DateTimeJsonConverter(),
                    new LongJsonConverter()
                }
        };
    }

    // config
    //    const string  compile time
    //    conf file
    //    enviromental variable  (linux docker)
    //    conf db
    //    consul vault


    // GET https://swapi.dev/api/planets/{id}/
    public async Task<Planet?> GetPlanetById(int id)
    {
        var url = $"{_baseApiUrl}/planets/{id}/";
        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        req.Headers.Add("accept", "application/json");

        using var response = await _http.SendAsync(req);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var planet = JsonSerializer.Deserialize<Planet?>(response.Content.ReadAsStream(), _jsonOptions);
            return planet;
        }
        else
        {
            // Error
            Console.WriteLine($"{response.RequestMessage}");
        }
        return null;
    }

    // GET https://swapi.dev/api/planets/
    public async Task<List<Planet>> GetPlanets()
    {
        var url = $"{_baseApiUrl}/planets/";

        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        req.Headers.Add("x-version", "123");
        req.Headers.Add("x-api-key", "accout1:1234");
        req.Headers.Add("accept", "application/json");
        req.Headers.Add("authorization", "Bearer JWT.daspdlañdlñaldñalñl");

        using var response = await _http.SendAsync(req);

        //var response = await _http.GetAsync(url);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var page = JsonSerializer.Deserialize<Page<Planet>>(response.Content.ReadAsStream(), _jsonOptions);
            return page.Results;

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
