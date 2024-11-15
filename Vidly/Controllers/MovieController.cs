using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Person A" },
                new Customer { Name = "Person B" },
                new Customer { Name = "Person C" }
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            // other action results -> 
            // return Content("Hello ledo");
            // return NotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public IActionResult Edit(int id)
        {
            return Content(String.Format("ID = {0}", id));
        }

        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex = {0} | sortBy = {1}", pageIndex, sortBy));
        }

        [Route("movie/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{1,2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("year: {0} | month: {1}", year, month));
        }
    }
}
