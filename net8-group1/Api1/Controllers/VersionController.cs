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

}


public class VersionInfo
{
    public string Version { get; set; }
    public string Name { get; set; }
    public DateTime Timestamp { get; set; }
    public string Server { get; set; }
    public string Environment { get; set; }
}
