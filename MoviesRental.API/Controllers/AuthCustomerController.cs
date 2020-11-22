using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AuthCustomerController : ControllerBase
    {
        private readonly AuthCustomerService _service;

        public AuthCustomerController(AuthCustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            _service.Register(customer);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Customer customer)
        {
            return Ok(_service.Login(customer));
        }
    }
}
