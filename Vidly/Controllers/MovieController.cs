using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationContext _context;

        public MovieController(ApplicationContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Route("movie/all")]
        public IActionResult GetAllMovies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            var viewModel = new AllMoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        [Route("movie/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var customer = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(customer);
        }

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
                Name = "Inception"
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
