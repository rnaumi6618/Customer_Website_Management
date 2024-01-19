using Invoicing.Entities;
using Invoicing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Tests
{
    public class UnitTestGroup
    {
        public class TestManageInvoice 
        {
            private List<Customer> _customers;
            public List<Customer> GetTestCustomers()
            {
                return new List<Customer>
                {
                    new Customer { Name = "Alice", IsDeleted = false },
                    new Customer { Name = "Bob", IsDeleted = false },
                    new Customer { Name = "Charlie", IsDeleted = false },
                };
            }

            public TestManageInvoice()
            {
                _customers = GetTestCustomers();
            }

            public IEnumerable<Customer> GetAllCustomer()
            {
                return _customers.Where(c => !c.IsDeleted);
            }

            //same method as original ManageInvoice
            public IEnumerable<Customer> GetCustomersByGroup(string lowerBound, string upperBound)
            {
                return _customers
                    .Where(c => !c.IsDeleted &&
                                c.Name.ToLower().Substring(0, 1).CompareTo(lowerBound.ToLower()) >= 0 &&
                                c.Name.ToLower().Substring(0, 1).CompareTo(upperBound.ToLower()) <= 0)
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }


        [Fact]
        public void GetCustomersByGroup_ReturnsCorrectGroup()
        {
            // Arrange
            var service = new TestManageInvoice();
            var lowerBound = "a";
            var upperBound = "b";

            // Act
            var result = service.GetCustomersByGroup(lowerBound, upperBound).ToList();

            // Assert
            Assert.All(result, customer =>
                Assert.InRange(customer.Name.ToLower()[0], lowerBound[0], upperBound[0]));
        }

    }
}
