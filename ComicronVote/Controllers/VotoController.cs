using ComicronVote.DTOs;
using ComicronVote.Models;
using ComicronVote.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ComicronVote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VotoController : ControllerBase
    {
        private readonly IVotoService service;

        public VotoController(IVotoService service)
        {
            this.service = service;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Voto>>> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("[action]")]
        public async Task<ActionResult<Somma>> TotaleVotiByCodiceFilmAsync (string codice)
        {
            Somma somma = new Somma();
            somma.SommaVoti = await service.SommaVotiByCodiceFilmAsync(codice);
            return Ok(somma);
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(VotoDTO voto)
        {
            await service.InsertAsync(voto);
            return Ok("Voto inserito ok!");
        }
    }
}
