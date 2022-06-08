using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Data.Dtos.Manager
{
    public class ReadManagerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Cinema> Cinemas { get; set; }
    }
}
