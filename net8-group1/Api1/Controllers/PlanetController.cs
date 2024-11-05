using Api1.Models;
using Api1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{

    [ApiController]
    [Route("/planets")]
    public class PlanetController : ControllerBase
    {
        private IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Planet>> GetAll()
        {
            return await _planetService.GetPlanets();
        }

        [HttpGet]
        [Route("{id}")]
        public Planet? GetById(int id)
        {
            return _planetService.GetPlanetById(id);
        }

    }
}
