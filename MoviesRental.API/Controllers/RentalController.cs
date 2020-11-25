using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesRental.API.Infrastructure;
using MoviesRental.DAL.Models;
using MoviesRental.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthRequired]
    public class RentalController : ControllerBase
    {
        private readonly RentalService _service;
        private readonly ILogger _logger;

        public RentalController(RentalService service, ILogger<ActorController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /*
         * Get : 
         * - get all rental
         */

        [HttpGet]
        public IActionResult GetAll() {
            try {
                _logger.LogInformation("### Controller Rental : get All rental ...");
                IEnumerable<Rental> rentals = _service.GetAll().ToList();
                return Ok(rentals);
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

    }
}
