namespace Unit_test_sample.Models
{
    public static class Extensions
    {

        public static CustomerDto AsDto(this Customer customer)
        {
            return new CustomerDto()
            {
                FullName = $"{customer.FirstName} {customer.LastName}",
                Mobile = customer.Contact,
                Email = customer.Email
            };

        }

    }
}