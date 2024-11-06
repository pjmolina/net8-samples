namespace Api1.Services;

using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Api1.Converters;
using Api1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public interface IPlanetService
{
    public Task<List<Planet>> GetPlanets();  // list  task async
    public Task<Planet?> GetPlanetById(int id);
}

public class PlanetService : IPlanetService
{
    private IConfiguration _config;
    private string _baseApiUrl = "";

    static readonly HttpClient client = new HttpClient();

    private JsonSerializerOptions _jsonOptions;


    public PlanetService(IConfiguration config)
    {
        _config = config;
        _baseApiUrl = config.GetValue<string>("StarWarsAPI:BaseApi") ?? "";

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new DateTimeJsonConverter(),
                new IntJsonConverter()
            }
        };
    }


    //  GET https://swapi.dev/api/planets/{id}/
    public async Task<Planet?> GetPlanetById(int id)
    {
        try
        {
            var url = $"{_baseApiUrl}/planets/{id}";

            var req = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };
            req.Headers.Add("x-version", "123");
            req.Headers.Add("accept", "application/json");
            req.Headers.Add("x-api-key", "user1:1234");
            req.Headers.Add("authorization", "Bearer JWT");

            using (var response = await client.SendAsync(req))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var planet = JsonSerializer.Deserialize<Planet>(response.Content.ReadAsStream(), _jsonOptions);
                    return planet;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        return null;
    }

    //  HTTP GET https://swapi.dev/api/planets/
    public async Task<List<Planet>> GetPlanets()
    {
        try
        {

            var url = $"{_baseApiUrl}/planets";

            // req / res 

            var req = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };
            req.Headers.Add("x-version", "123");
            req.Headers.Add("accept", "application/xml");
            req.Headers.Add("x-api-key", "user1:1234");
            req.Headers.Add("authorization", "Bearer JWT");


            using (var response = await client.SendAsync(req))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var page = JsonSerializer.Deserialize<Page<Planet>>(response.Content.ReadAsStream(), _jsonOptions);
                    return page.Results;
                }
            }



            //using (var response = await client.GetAsync(url))  // launch ----------- ?? ms ---- response
            //{
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var options = new JsonSerializerOptions
            //        {
            //           PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            //           PropertyNameCaseInsensitive = true,
            //           Converters = {
            //                new DateTimeJsonConverter(),
            //                new IntJsonConverter()
            //           }
            //        };

            //        var page = JsonSerializer.Deserialize<Page<Planet>>(response.Content.ReadAsStream(), options);
            //        return page.Results;

            //        // Debugging version
            //        //// 200 ok
            //        //foreach (var header in response.Content.Headers)
            //        //{
            //        //    var values = string.Join(", ", header.Value);

            //        //    Console.WriteLine($"{header.Key} = {values}");
            //        //}
            //        //using (var reader = new StreamReader(response.Content.ReadAsStream()))
            //        //{
            //        //    var text = reader.ReadToEnd();
            //        //    Console.WriteLine(text);
            //        //}

            //    }
            //    else
            //    {
            //        // error handling
            //    }
            //}
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        return [];
    }
}
