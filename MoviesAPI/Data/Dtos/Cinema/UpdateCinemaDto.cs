using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Cinema Name is mandatory")]
        public string Name { get; set; }
    }
}
