using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pancase.Models;
using Pancase.Services;

namespace Pancase.Controllers
{
    public class CustomersController : Controller
    {
        private readonly PancaseContext _context;
        private readonly ICustomerService _customerService;

        public CustomersController(PancaseContext context,ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string SearchString)
        {
            var customers = await _customerService.Seek(SearchString);
            var viewModel = new CustomersViewModel();
            viewModel.Customers = customers;
            return View(viewModel);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var customer = await _customerService.Fetch(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View(new CreateCustomerViewModel());
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCustomerViewModel createCustomerViewModel)
        {
            var customer = new Customer();
            if (ModelState.IsValid)
            {
                var created = await _customerService.Create(createCustomerViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(createCustomerViewModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var updateCustomerViewModel = new UpdateCustomerViewModel();
            var customer = await _customerService.Fetch(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                updateCustomerViewModel.Id = customer.Id;
                updateCustomerViewModel.EmploymentType = customer.EmploymentType;
                updateCustomerViewModel.EmploymentTypeNotes = customer.EmploymentTypeNotes;
                updateCustomerViewModel.FirstName = customer.FirstName;
                updateCustomerViewModel.LastName = customer.LastName;
                updateCustomerViewModel.PhoneNumber = customer.PhoneNumber;
                updateCustomerViewModel.Ssn = customer.Ssn;

            }

            return View(updateCustomerViewModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCustomerViewModel updateCustomerViewModel)
        {
            var customer = new Customer();
            if (ModelState.IsValid)
            {
                if (id != updateCustomerViewModel.Id)
                {
                    return NotFound();
                }
                else
                {
                    await _customerService.Update(updateCustomerViewModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateCustomerViewModel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var customer = await _customerService.Fetch(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerService.Fetch(id);
            var removed = await _customerService.Delete(customer);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _customerService.Fetch(id) != null;
           // return _context.Customer.Any(e => e.Id == id);
        }
    }
}
