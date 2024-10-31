namespace Api2.Controllers;

using Api2.Dto;
using Api2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Pizza controler to query, queryById create, update, delete pizzas
/// </summary>
[ApiController]
[Route("pizzas")]
public class PizzaController : ControllerBase
{
    private IPizzaService _pizzaService;

    public PizzaController(IPizzaService pizzaService)
    {
        // Dependency Injection -
        // Inversion of Control

        _pizzaService = pizzaService;  // new PizzaServiceV4()
    }


    [HttpGet]
    public List<PizzaDto> GetAll()
    {
        return _pizzaService.GetAll();
    }
    [HttpGet]
    [Route("{id}")]
    public PizzaDto? GetById([FromRoute] int id)
    {
        return _pizzaService.GetById(id);
    }

    [HttpPost]
    public PizzaDto CreatePizza([FromBody] PizzaUpdateDto pizza)
    {
        return _pizzaService.Create(pizza);
    }

    [HttpPut]
    [Route("{id}")]
    public PizzaDto? UpdatePizza([FromRoute] int id, [FromBody]  PizzaUpdateDto pizza)
    {
        return _pizzaService.Update(id, pizza);
    }

    [HttpDelete]
    [Route("{id}")]
    public PizzaDto? Delete([FromRoute] int id)
    {
        return _pizzaService.Delete(id);
    }

}
