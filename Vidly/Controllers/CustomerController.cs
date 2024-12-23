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

        [Route("customer/new")]
        public IActionResult RegisterNewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult SaveCustomerDetails(Customer customer)
        {
            if (customer.Id == 0)
            {
                var newCustomer = new Customer
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate,
                    IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                    MembershipType = customer.MembershipType,
                    MembershipTypeId = customer.MembershipTypeId,
                };

                _context.Customers.Add(newCustomer);
            }
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                existingCustomer.MembershipType = customer.MembershipType;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;                
            }

            
            _context.SaveChanges();


            return RedirectToAction("GetAllCustomers", "Customer");
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

        [Route("customer/{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        public IActionResult UpdateCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return BadRequest();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm", viewModel);
        }
    }
}
