using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> Customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "John Doe", Age = 21 },
            new Customer { Id = 2, Name = "Jane Doe", Age = 17 },
            new Customer { Id = 3, Name = "Bob Spade", Age = 32 }
        };

        [Route("customer/all")]
        public IActionResult GetAllCustomers()
        {
            var viewModel = new AllCustomersViewModel
            {
                Customers = Customers
            };

            return View(viewModel);
        }

        [Route("customer/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = Customers[id];

            return View(customer);
        }
    }
}
