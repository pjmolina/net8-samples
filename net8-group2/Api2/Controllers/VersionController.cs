namespace Api2.Controllers;

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
            Environment = "local",
            Name = "Api2",
            Version = "1.2.3",
            Timestamp = DateTime.Now,
            Server = Dns.GetHostName()
        };
    }
}

public class VersionInfo
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Environment { get; set; }
    public DateTime Timestamp { get; set; }
    public string Server { get; set; }

}
