namespace Api2.Controllers;

using Api2.Models;
using Api2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("planets")]
[ApiController]
public class PlanetController : ControllerBase
{
    private IPlanetService _planetService;

    public PlanetController(IPlanetService planetService)
    {
        _planetService = planetService;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Planet>>> GetAll()
    {
        try
        {
            return Ok(await _planetService.GetPlanets());
        }
        catch (Exception ex)
        {
            return this.Problem(ex.Message, null, 503);
        }
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Planet?>> GetById(int id)
    {
        var planet = await _planetService.GetPlanetById(id);
        if (planet == null)
        {
            // 404 Not found
            return NotFound($"The planet you are looking for does not exists: {id}");
        }
        else
        {
            // 200 OK
            return Ok(planet);
        }
    }

}
