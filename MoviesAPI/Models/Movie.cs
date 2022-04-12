using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie title is mandatory")]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        public string Genre { get; set; }
        [Range(1, 600)]
        public int Duration { get; set; }
    }
}
