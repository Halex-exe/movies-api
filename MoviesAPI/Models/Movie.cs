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
        [Required(ErrorMessage = "Movie Director is mandatory")]
        public string Director { get; set; }
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "Duration time range is between 1 and 600 minutes")]
        public int Duration { get; set; }
        public int AgeClassification { get; set; }
    }
}
