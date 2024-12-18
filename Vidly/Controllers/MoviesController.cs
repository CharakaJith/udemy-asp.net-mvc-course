using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Inception",
                Type = "Sci-Fi"
            };

            return View(movie);
        }
    }
}
