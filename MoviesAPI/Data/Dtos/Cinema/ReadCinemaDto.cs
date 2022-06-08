using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Cinema Name is mandatory")]
        public string Name { get; set; }
        public object Address { get; set; }
        public object Manager { get; set; }
    }
}
