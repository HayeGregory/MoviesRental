﻿using Microsoft.AspNetCore.Http;
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
    public class FilmController : ControllerBase
    {
        private readonly FilmService _service;

        public FilmController(FilmService service)
        {
            _service = service;
        }

        /*
         * Get :
         * - Get all
         * - Get all films Short Info
         * - get all Films Full Info
         */
        //todo : get by words

        [HttpGet]
        public IEnumerable<Film> GetAll() {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("FilmShort")]
        public IEnumerable<FilmShort> GetAllShort() {
            return _service.GetAllFilmShort();
        }

        [HttpGet]
        [Route("FilmFull")]
        public IEnumerable<FilmFull> GetAllFull()
        {
            return _service.GetAllFilmFull();
        }
    }
}
