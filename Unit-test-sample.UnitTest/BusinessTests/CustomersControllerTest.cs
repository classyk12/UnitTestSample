using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Unit_test_sample.Fundamentals;
using Unit_test_sample.Interfaces;
using Unit_test_sample.Models;

namespace Unit_test_sample.UnitTest
{
    [TestFixture]
    public class CustomersControllerTest
    {
        private Mock<ICustomerService> interfaceStub = new Mock<ICustomerService>();

        [Test]
        public async Task GetCustomer_GetCustomerByIdWithValidId_ReturnsCustomer()
        {
            var items = CustomerMocks.GenerateRandomCustomer();
            //ARRANGE
            interfaceStub.Setup(a => a.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(items);
            var controller = new CustomersController(interfaceStub.Object);

            //Act
            var result = await controller.GetCustomer(Guid.NewGuid().ToString());

            //Assert
            Assert.That(result.Value, Is.TypeOf<CustomerDto>());

            //compare that the result returned is actually the correct dto, compares property by property
            // result.Value.Should().BeEquivalentTo(items, options => options.ComparingByMembers<Customer>());
        }

        [Test]
        public async Task GetCustomer_AllCustomers_ReturnsListOfCustomer()
        {
            var items = CustomerMocks.GenerateMultipleRandomCustomer();
            //ARRANGE
            interfaceStub.Setup(a => a.GetAllAsync()).ReturnsAsync(items);
            var controller = new CustomersController(interfaceStub.Object);

            //Act
            var result = await controller.GetAll();

            //Assert
            Assert.That(result.Value, Is.TypeOf<List<CustomerDto>>());
        }

        [Test]
        public async Task GetCustomer_GetCustomerByWithInvalidId_ReturnsNotFound()
        {
            //ARRANGE
            // -- set interface up to return a fake value
            interfaceStub.Setup(a => a.GetByIdAsync(It.IsAny<Guid>().ToString())).ReturnsAsync(null as Customer);

            //--- arrange the controllr
            var controller = new CustomersController(interfaceStub.Object);

            //Act
            var result = await controller.GetCustomer(Guid.NewGuid().ToString());

            //NUNIT assertion
            Assert.That(result.Result, Is.TypeOf<NotFoundResult>());

            //fluent assertions
            //  result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Test]
        public async Task GetCustomer_CreateCustomer_ReturnOkResult()
        {
            var item = CustomerMocks.GenerateRandomCustomer();
            var controller = new CustomersController(interfaceStub.Object);

            //Act
            var result = await controller.Create(CustomerMocks.GenerateRandomCustomer());

            //Assert
            Assert.That(result.Value, Is.TypeOf<Customer>());
        }

        [Test]
        public async Task GetCustomer_UpdateCustomer_ReturnsNotFound()
        {
            var item = CustomerMocks.GenerateRandomCustomer();
            interfaceStub.Setup(a => a.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(null as Customer);
            var controller = new CustomersController(interfaceStub.Object);

            var result = await controller.Update(Guid.NewGuid().ToString(), CustomerMocks.GenerateRandomCustomer());

            //Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task GetCustomer_UpdateCustomer_ReturnsNoContent()
        {
            var item = CustomerMocks.GenerateRandomCustomer();
            interfaceStub.Setup(a => a.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(item);
            var controller = new CustomersController(interfaceStub.Object);

            //arrange mock object to update
            var existingItem = new Customer
            {
                Id = item.Id,
                FirstName = "firstname",
                LastName = "ln",
                Email = "email",
                Contact = "c"
            };

            var result = await controller.Update(Guid.NewGuid().ToString(), existingItem);

            //Assert
            Assert.That(result, Is.TypeOf<NoContentResult>());
        }

        [Test]
        public async Task GetCustomer_DeleteCustomer_ReturnNoContent()
        {
            var item = CustomerMocks.GenerateRandomCustomer();
            interfaceStub.Setup(a => a.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(item);
            var controller = new CustomersController(interfaceStub.Object);

            var result = await controller.Delete(item.Id);

            //Assert
            Assert.That(result, Is.TypeOf<NoContentResult>());
        }

        [Test]
        public async Task GetCustomer_AllMatchingCustomers_ReturnsMatchingListOfCustomer()
        {
            string searchParam = "skil";
            var items = CustomerMocks.GenerateListOfCustomer();
            //ARRANGE
            interfaceStub.Setup(a => a.GetAllAsync()).ReturnsAsync(items);
            var controller = new CustomersController(interfaceStub.Object);

            //Act
            var result = await controller.GetAll(searchParam);

            //assert
            result.Value.Should().OnlyContain(c => !c.FullName.Contains(items[0].FirstName) || c.FullName.Contains(items[1].FirstName));
        }

    }
}
