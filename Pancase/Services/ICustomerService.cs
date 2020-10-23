using Pancase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pancase.Services
{
    public interface ICustomerService
    {
        Task<bool> Create(CreateCustomerViewModel createCustomerViewModel);
        Task<bool> Delete(Customer customer);
        Task<UpdateCustomerViewModel> Update(UpdateCustomerViewModel updateCustomerViewModel);
        Task<IEnumerable<Customer>> Seek(string name);
        Task<Customer> Fetch(int? id);
    }
}
