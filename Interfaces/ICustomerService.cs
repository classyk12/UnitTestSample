using System.Collections.Generic;
using System.Threading.Tasks;
using Unit_test_sample.Models;

namespace Unit_test_sample.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
        Task<Customer> CreateAsync(Customer customer);
        Task UpdateAsync(string id, Customer customer);
        Task DeleteAsync(string id);
        Task<long> Find (string name);
    }
}