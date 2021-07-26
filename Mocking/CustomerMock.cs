using System;
using System.Collections.Generic;

namespace Unit_test_sample.Models
{
    public static class CustomerMocks
    {
        private static readonly Random _random = new Random();
        public static Customer GenerateRandomCustomer()
        {
            return new Customer
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = null,
                LastName = Guid.NewGuid().ToString(),
                Contact = _random.Next(1000000000, 1111111111).ToString(),
                Email = Guid.NewGuid().ToString() + "@gmail.com"
            };
        }

        public static List<Customer> GenerateMultipleRandomCustomer()
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i <= 6; i++)
            {
                customers.Add(GenerateRandomCustomer());
            }
            return customers;
        }

        public static List<Customer> GenerateListOfCustomer()
        {
           var customers = new List<Customer>
           {
               new Customer {FirstName = "tester"},
               new Customer {FirstName = "van-tester"},
               new Customer {FirstName = "skilashi"},
           };

           return customers;
        }
    }
}