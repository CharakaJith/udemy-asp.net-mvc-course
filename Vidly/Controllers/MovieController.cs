using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movies
        public IActionResult Index(int? pageIndex, string? sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }

            return Content(String.Format("pageIndex: {0} & sortBy: {1}", pageIndex, sortBy));
        }

        // GET: Movies/Random
        public IActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Inception",
                Type = "Sci-Fi"
            };
            var customers = new List<Customer>
            {
                new Customer { Name = "customer one" },
                new Customer { Name = "customer two" },
                new Customer { Name = "customer two" }
            };

            var ViewModel = new RandomMovieViewModel 
            { 
                Movie = movie, 
                Customers = customers 
            };

            return View(ViewModel);
        }

        // GET: Movies/Edit/1
        public IActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        [Route("movie/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(01, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("year: {0} & month: {1}", year, month));
        }
    }
}
