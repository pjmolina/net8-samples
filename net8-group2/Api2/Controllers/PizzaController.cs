namespace Api2.Controllers;

using Api2.Dto;
using Api2.Models;
using Api2.Services;
using Microsoft.AspNetCore.Authorization;
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
    private IConfiguration _config;

    public PizzaController(IPizzaService pizzaService, IConfiguration config)  // mock   DECOUPLING
    {
        // Dependency Injection -
        // Inversion of Control

        _pizzaService = pizzaService;  // new PizzaServiceV4()  // fACTORY ctx -> new v1 new v2
        _config = config;
    }

    // GET /pizzas  -- all pizzas
    // GET /pizzas?q=carbo  
    // GET /pizzas?min=10&q=marga&max=20

    [HttpGet]
    [Authorize(Roles = "admin, operator")]
    public List<PizzaDto> GetAll([FromQuery] string? q, [FromQuery] decimal? max, [FromQuery] decimal? min,
        [FromHeader(Name = "x-api-key")] string? password)
    {
        var wellKnownPassword = _config.GetValue<string>("MasterPassword");

        if (!wellKnownPassword.Equals(password))
        {
            return []; // you shall not pass
        }

        var criteria = new PizzaSearchCriteria
        {
            Query = q,
            MinPrice = min,
            MaxPrice = max
        };

        return _pizzaService.GetAll(criteria);
    }
    [HttpGet]
    [Route("{id}")]
    public PizzaDto? GetById([FromRoute] int id)
    {
        return _pizzaService.GetById(id);
    }

    [HttpPost]
    public ActionResult<PizzaDto> CreatePizza([FromBody] PizzaUpdateDto pizza)
    {
        // 200 OK
        // 201 Created  POST /pizzas ->   /pizzas/5
        var obj = _pizzaService.Create(pizza);
        var uri = new Uri($"https://localhost:7136/pizzas/{obj.Id}/");
        return Created(uri, obj);
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
