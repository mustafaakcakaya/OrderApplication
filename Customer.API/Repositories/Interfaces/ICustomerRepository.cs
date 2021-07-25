using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<string> CreateAsync(Entities.Customer customer);
        Task<bool> UpdateAsync(Entities.Customer customer);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<Entities.Customer>> GetAsync();
        Task<Entities.Customer> GetAsync(string id);
        Task<bool> ValidateAsync(string id);

    }
}
