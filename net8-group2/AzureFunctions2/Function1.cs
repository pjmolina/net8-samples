using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions2
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run1([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {

           

            _logger.LogInformation("C# HTTP trigger function processed a request. from group2.");

            // throw new Exception("error happened!!!");

            return new OkObjectResult("Welcome to Azure Functions fun1 Group 2!  v2");
        }

        [Function("Function2")]
        public IActionResult Run2([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var t0 = DateTime.Now;

            // -> bd  IO -> 1000s
            // slow... compute
            _logger.LogInformation("C# HTTP trigger function processed a request. fun 2 from group2.");

            var t1 = DateTime.Now;
            var ellapsed = (t1 - t0).TotalMilliseconds;

            return new OkObjectResult($"Welcome to Azure Functions fun2 Group 2! v2, time: {ellapsed} ms");
        }
    }
}
