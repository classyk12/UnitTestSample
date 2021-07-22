using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Unit_test_sample.Interfaces;
using Unit_test_sample.Models;

namespace Unit_test_sample.Fundamentals
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly IConfiguration _config;
        public CustomerService(IConfiguration config)
        {
            _config = config;

            var client = new MongoClient(_config["DeveloperDatabaseConfiguration:ConnectionString"]);
            var database = client.GetDatabase(_config["DeveloperDatabaseConfiguration:DatabaseName"]);
            _customer = database.GetCollection<Customer>(_config["DeveloperDatabaseConfiguration:CustomerCollectionName"]);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var result = await _customer.Find(c => true).ToListAsync();
            return result;
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            var result = await _customer.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _customer.InsertOneAsync(customer);
            return customer;
        }

        public async Task UpdateAsync(string id, Customer customer)
        {
            await _customer.ReplaceOneAsync(c => c.Id == id, customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _customer.DeleteOneAsync(c => c.Id == id);
        }

        [System.Obsolete]
        public async Task<long> Find(string name)
        {
            var result = await _customer.CountAsync(c => c.FirstName.ToLower() == (name.ToLower()));
            return result;
        }
    }
}