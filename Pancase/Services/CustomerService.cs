using Microsoft.EntityFrameworkCore;
using Pancase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pancase.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly PancaseContext _context;

        public CustomerService (PancaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CreateCustomerViewModel createCustomerViewModel) {

            var customer = new Customer();
            customer.EmploymentType = createCustomerViewModel.EmploymentType;
            customer.FirstName = createCustomerViewModel.FirstName;
            customer.LastName = createCustomerViewModel.LastName;
            customer.EmploymentTypeNotes = createCustomerViewModel.EmploymentType == EmploymentType.Other ? createCustomerViewModel.EmploymentTypeNotes : null;
            customer.PhoneNumber = createCustomerViewModel.PhoneNumber;
            customer.Ssn = createCustomerViewModel.Ssn;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Customer customer) {

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UpdateCustomerViewModel> Update(UpdateCustomerViewModel updateCustomerViewModel) {
            var customer = new Customer
            {
                EmploymentType = updateCustomerViewModel.EmploymentType,
                FirstName = updateCustomerViewModel.FirstName,
                LastName = updateCustomerViewModel.LastName,
                EmploymentTypeNotes = updateCustomerViewModel.EmploymentType == EmploymentType.Other ? updateCustomerViewModel.EmploymentTypeNotes : null,
                PhoneNumber = updateCustomerViewModel.PhoneNumber,
                Ssn = updateCustomerViewModel.Ssn,
                Id = updateCustomerViewModel.Id
            };
            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await Fetch(customer.Id) == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return updateCustomerViewModel;
        }


        public async Task<IEnumerable<Customer>> Seek(string name) {

            var customers = from c in _context.Customer select c;

            if (!String.IsNullOrEmpty(name))
            {
                customers = customers.Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name));
            }

            return await customers.ToListAsync();
        }

        public async Task<Customer> Fetch(int? id)
        {

            if (id == null)
            {
                return null;
            }

            var customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            return customer;
        }
    }
}
