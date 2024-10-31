using Api1.Dto;
using Api1.Services;
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

        [HttpGet]
        public List<PizzaDto> GetAll()
        {
            return _pizzaService.GetAll();
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
            foreach (var pizza in _pizzaService.GetAll())
            {
                _pizzaService.Delete(pizza.Id);
            }
            return true;
        }

    }
}
