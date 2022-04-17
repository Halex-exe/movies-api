using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                Duration = movieDto.Duration,
                Director = movieDto.Director
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(filme => filme.Id == id);

            if (movie != null)
            {
                ReadMovieDto readMovieDto = new ReadMovieDto
                {
                    Title = movie.Title,
                    Genre = movie.Genre,
                    Duration = movie.Duration,
                    Director = movie.Director,
                    GetTime = DateTime.Now
                };
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(filme => filme.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            movie.Title = movieDto.Title;
            movie.Genre = movieDto.Genre;
            movie.Duration = movieDto.Duration;
            movie.Director = movieDto.Director;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(filme => filme.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();

        }
    }
}