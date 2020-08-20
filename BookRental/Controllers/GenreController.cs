using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookRental.Models;
using BookRental.RepositoryPattern;

namespace BookRental.Controllers
{
    public class GenreController : ApiController
    {
        private GenreRepository genreRepository = new GenreRepository();

        [HttpGet]
        [Route("api/Genre/GetGenres")]
        public List<Genre>  GetGenres ()
        {
            return genreRepository.Display();
        }


    }
}
