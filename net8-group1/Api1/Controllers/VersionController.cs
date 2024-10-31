namespace Api1.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("/version")]
public class VersionController : ControllerBase
{
    [HttpGet]
   
    public VersionInfo GetVersion()
    {
        return new VersionInfo
        {
            Name = "Api1",
            Environment = "local",
            Timestamp = DateTime.Now,
            Version = "1.2.3",
            Server = Dns.GetHostName(),
        };
    }


    [HttpGet]
    [Route("sum")]  // GET      GET /version/sum?a=1&b=2     (query string)
    public int Sum([FromQuery] int a, [FromQuery] int b)
    {
        return a + b;
    }

    [HttpGet]
    [Route("sum2/{a}/{b}")]  // GET /version/sum2/1/2      (Route)
    public double Sum2([FromRoute] double a, [FromRoute] double b)
    {
        return a + b;
    }


    private static int _seq = 1;

    [HttpPost]
    [Route("user")]
    public UserDto CreateUser([FromBody] UserDto user)
    {
        // simulationg we are storing this in DB

        user.Id = _seq++;
        return user;
    }

}

public class UserDto  // Data Transfer Object ==  Contract
{
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


public class VersionInfo
{
    public string Version { get; set; }
    public string Name { get; set; }
    public DateTime Timestamp { get; set; }
    public string Server { get; set; }
    public string Environment { get; set; }
}
