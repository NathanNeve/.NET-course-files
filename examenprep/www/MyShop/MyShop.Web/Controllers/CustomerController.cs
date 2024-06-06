using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerController(IRepository<Customer> repo)
        {
            _customerRepository = repo;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                //var customers = _context.Customers.ToList();
                var customers = _customerRepository.All();
                return View(customers);
            }
            else
            {
                var customers = new[] { _customerRepository.Get(id.Value) };
                return View(customers);
            }
        }
    }
}
