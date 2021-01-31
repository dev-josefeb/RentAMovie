using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAMovie.Models;
using RentAMovie.ViewModels;
using System.Data.Entity;

namespace RentAMovie.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> _customers { get; set; }
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
           //_customers = GetCustomers().ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        //HttPost is used since we are modifying the form 
        //This is done so it is never called by using Http Get 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if(!ModelState.IsValid)
                return View("CustomerForm", new CustomerFormViewModel { Customer = customer, MembershipTypes = _context.MembershipTypes.ToList() });

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Can also use Automapper to set property values
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                // Security Loopholes here since all properties can be updated or added 
                //TryUpdateModel(customerInDb);

            }

            _context.SaveChanges();

            return RedirectToAction("Customers","Customer");
        }

        // GET: Customer
        [Route("Customers/")]
        public ActionResult Customers()
        {
            var viewModel = new CustomersViewModel
            {
                Customers = _context.Customers.Include(c=>c.MembershipType).ToList()
            };

            return View(viewModel);

            //var customers = _context.Customers.ToList();
            //return View(customers.ToList());

        }


        [Route("Customer/Details/{id}/")]
        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            //return View(customer);
            return View();

            //return View(_context.Customers.FirstOrDefault(c => c.Id == id).Name);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            { 
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };


            return View("CustomerForm",viewModel);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=0, Name = "Tekken Kumar"},
                new Customer{Id=1, Name = "George Henry"},
                new Customer{Id=2, Name = "Olsen Alesund"},
                new Customer{Id=3, Name = "Heebar Chang"},
            };
        }
    }
}