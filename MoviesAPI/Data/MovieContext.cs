using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext>opt) : base (opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
