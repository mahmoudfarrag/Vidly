using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershioTybes = _context.MembershipTybes;
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTybes = membershioTybes
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTybes = _context.MembershipTybes
            };
            if (customer == null)
                return HttpNotFound();
            return View("CustomerForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //validation 
            if (!ModelState.IsValid)
            {
                //return same view
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,//so to not delete data in form
                    MembershipTybes = _context.MembershipTybes.ToList()
                };
                return View("CustomerForm", viewModel);

            }
            //check id if ==0 then this is add procedd
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                //this is update process
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTybeId = customer.MembershipTybeId;
            }
            _context.SaveChanges();

           return RedirectToAction("Index","Customers");
        }
        public ActionResult Index()
        {
           
            return View();
        }
       
        public ActionResult Detailes(int id) {
            var customer = _context.Customers.Include(c => c.MembershipTybe).SingleOrDefault(c => c.Id == id);
            
            return View(customer);
        }
        
        
    }
}