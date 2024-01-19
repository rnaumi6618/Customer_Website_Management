/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Entities;
using Invoicing.Services;

namespace Invoicing.Tests
{
    public class UnitTestAmount


    {
        [Fact]
        public void TestItemsTotalAmount()
        {

            // Arrange:
            Invoice invoice = new Invoice()
            {
                InvoiceLineItem = new List<InvoiceLineItem>()
            };

            invoice.InvoiceLineItem.Add(new InvoiceLineItem() { Description = "ghghg", Amount = 1000.00});
            invoice.InvoiceLineItem.Add(new InvoiceLineItem() { Description = "ppp", Amount = 1000.00});


            // same equation is used to calculate all items total
            //Act
            double? total = invoice.InvoiceLineItem.Sum(item => item.Amount).GetValueOrDefault();

            double expectedTotal = 2000.00;

            // Assert:
            Assert.Equal(expectedTotal, total);
       
        }
    }
}