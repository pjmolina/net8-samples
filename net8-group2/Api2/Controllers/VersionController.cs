namespace Api2.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/version")]
public class VersionController : ControllerBase
{
    [HttpGet]
    //[Produces("application/xml")]
    public VersionInfo GetVersion()
    {
        return new VersionInfo
        {
            Environment = "local",
            Name = "Api2",
            Version = "1.2.3",
            Timestamp = DateTime.Now,
            Server = Dns.GetHostName()
        };
    }

    [HttpGet]
    [Route("sum1/{a}/{b}")]    // GET /version/sum1/1/2
    public int Sum1([FromRoute] int a, [FromRoute] int b)
    {
        return a + b;
    }

    [HttpGet]
    [Route("sum2")]    // GET /version/sum1?a=3&b=4    (query string) 
    public int Sum2([FromQuery] int a, [FromQuery] int b)
    {
        return a + b;
    }

    private static int seq = 1;

    [HttpPost]
    [Route("user")]
    public UserDto CreateUser(UserDto user)
    {
        user.Id = seq++;
        // storing DB (simulated)
        return user;
    }

}

public class UserDto   //DTO = Data Transfer Object -  Contracts 
{
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class VersionInfo
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Environment { get; set; }
    public DateTime Timestamp { get; set; }
    public string Server { get; set; }

}
