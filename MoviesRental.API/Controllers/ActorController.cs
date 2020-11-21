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

        /*
         * Get :
         * - Get all
         * - Get all actor by film id
         * - get all initials of actor
         */

        [HttpGet]
        public IEnumerable<Actor> GetAll() {
            return _service.GetAll();
        }

        [HttpGet("{IdFilm}")]
        public IEnumerable<Actor> GetAllByFilmId(int IdFilm) {
            return _service.GetAllByFilmId(IdFilm);
        }

        [HttpGet]
        [Route("Initials")]
        public IEnumerable<ActorInitials> GetAllInitials()
        {
            return _service.GetAllInitials();
        }

        [HttpGet("Initials/{initials}")]
        public IEnumerable<Actor> GetAllByInitials(string initials)
        {
            return _service.GetAllByInitials(initials);
        }

    }
}
