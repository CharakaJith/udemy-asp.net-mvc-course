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
        [Display(Name = "Released Date")]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        public DateOnly AddedDate { get; set; }

        [Required]
        [Display(Name = "Number of Stocks")]
        public int NumOfStocks { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Movie Genre")]
        public int GenreId { get; set; }
    }
}
