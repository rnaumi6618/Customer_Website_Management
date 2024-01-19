using Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Tests
{
    public class UnitTestDueDate
    {

        [Fact]
        public void InvoiceDueDate_ReturnsCorrectDate()
        {
            // Arrange
            var invoice = new Invoice
            {
                InvoiceDate = new DateTime(2023, 1, 1),
                PaymentTerms = new PaymentTerms { DueDays = 30 },

            };


            DateTime expectedDueDate = new DateTime(2023, 1, 31);

            //same equation is used to calculate due date in original program
            // Act
            DateTime actualDueDate = (DateTime)(invoice.InvoiceDate?.AddDays(Convert.ToDouble(invoice.PaymentTerms?.DueDays)));

            // Assert
            Assert.Equal(expectedDueDate, actualDueDate);
            
        }
    }
}
