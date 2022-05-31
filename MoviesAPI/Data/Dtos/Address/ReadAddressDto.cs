using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class ReadAddressDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }

    }
}