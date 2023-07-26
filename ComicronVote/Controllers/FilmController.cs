using ComicronVote.Models;
using ComicronVote.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ComicronVote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FilmController : ControllerBase
    {
        private readonly IFilmService service;

        public FilmController(IFilmService service)
        {
            this.service = service;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Film>>> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<string>> InsertAsync(Film film)
        {
            await service.InsertAsync(film);
            return Ok("Inserito film!");
        }
    }
}
