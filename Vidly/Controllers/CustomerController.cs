using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationContext _context;

        public CustomerController(ApplicationContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("customer/all")]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new AllCustomersViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customer/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
    }
}
