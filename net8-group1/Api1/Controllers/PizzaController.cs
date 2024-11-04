using Api1.Dto;
using Api1.Models;
using Api1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("/pizzas")]
    public class PizzaController : ControllerBase
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService) : base()
        {
            // Depedency Injection
            // Inversion of Control

            _pizzaService = pizzaService;
        }


        // query pizzas, create pizzas, change CRUD

        // GET /pizza?q=marga
        // GET /pizza?max=20.5&min=10&q=tomato
        [HttpGet]
        public List<PizzaDto> GetAll([FromQuery] string? q, [FromQuery] decimal? min, [FromQuery] decimal? max)
        {
            var searchCriteria = new PizzaSearchCriteria
            {
                Query = q,
                MaxPrice = max,
                MinPrice = min
            };

            return _pizzaService.GetAll(searchCriteria);
        }
        [HttpGet]
        [Route("{id}")]
        public PizzaDto GetById([FromRoute] int id)
        {
            var found = _pizzaService.GetById(id);
            return found;
        }
        
        [HttpPost]
        public PizzaDto Create([FromBody] PizzaDto pizza)
        {
            return _pizzaService.Create(pizza);
        }
        // [Authorize("admin")]
        [HttpPut]
        [Route("{id}")]
        public PizzaDto Update([FromRoute] int id, [FromBody] PizzaDto pizza)
        {
            return _pizzaService.Update(id, pizza);
        }

        [HttpDelete]
        [Route("{id}")]
        public PizzaDto Delete([FromRoute] int id)
        {
            return _pizzaService.Delete(id);
        }

        [HttpDelete]
        [Route("delete-all")]
        public bool Delete()
        {
            foreach (var pizza in _pizzaService.GetAll(new PizzaSearchCriteria()))
            {
                _pizzaService.Delete(pizza.Id);
            }
            return true;
        }

    }
}
