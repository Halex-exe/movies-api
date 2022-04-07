using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;

        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            return movies;
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    return movie;
                }
            }
            return null;
        }
    }
}