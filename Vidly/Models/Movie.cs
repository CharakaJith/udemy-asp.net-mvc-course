using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public DateOnly AddedDate { get; set; }

        [Required]
        public int NumOfStocks { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}
