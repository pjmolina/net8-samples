using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("pizzas")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly PizzaService _service;

        public PizzaController(
            ILogger<PizzaController> logger,
            PizzaService service
            )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Pizza>> Query()
        {
            return Ok(_service.Query());
        }
        [HttpPost()]
        public ActionResult<Pizza> Create(Pizza pizza)
        {
            return Ok(_service.Create(pizza));
        }
        [HttpPut("{id}")]
        public ActionResult<Pizza> Update(int id, Pizza pizza)
        {
            return Ok(_service.Update(id, pizza));
        }
        [HttpDelete("{id}")]
        public ActionResult<Pizza> Delete(int id)
        {
            var res = _service.Delete(id);
            return res == null 
                ? NotFound(id) 
                : Ok(res);
        }

    }
}
