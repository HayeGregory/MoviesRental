using Microsoft.AspNetCore.Mvc;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System.Collections.Generic;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ActorService _service;

        public ActorController(ActorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Actor> GetAll() {
            return _service.GetAll();
        }

        [HttpGet("{IdFilm}")]
        public IEnumerable<Actor> GetALLByFilmId(int IdFilm) {
            return _service.GetAllByFilmId(IdFilm);
        }
    }
}
