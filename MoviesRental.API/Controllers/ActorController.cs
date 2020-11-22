using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesRental.API.Infrastructure;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthRequired]
    public class ActorController : ControllerBase
    {
        private readonly ActorService _service;
        private readonly ILogger _logger;           // mise en place pour le log 

        public ActorController(ILogger<ActorController> logger, ActorService service)
        {
            _service = service;
            _logger = logger;
        }

        /*
         * Get :
         * - Get all
         * - Get all actor by film id
         * - get all initials of actor
         */

        //[HttpGet]
        //public IEnumerable<Actor> GetAll()
        //{
        //    _logger.LogInformation("Get all du controlleur Actor appelé...");
        //    return _service.GetAll();
        //}

        /* Get ALL avec gestion erreur badrequest 
         * -> implique un retour IActionResult
         * -> a la consommation : gerer le code de retour (todo ?? bien mettre les code erreor dans la web api)
         */
        [HttpGet]
        public IActionResult GetAll() {
            try {
                _logger.LogInformation("Get all du controlleur Actor appelé...");
                // ne pas lancer directement le service.getall() 
                // dans le OK --> yield return , il faut consommer avec le ToList() pour declencher l'erreur ici
                IEnumerable<Actor> actors = _service.GetAll().ToList();
                return Ok(actors);

            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        /*=====================================================================================================================*/


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
             initials = initials.ToUpper();
            return _service.GetAllByInitials(initials[0], initials[1]);
        }

    }
}
