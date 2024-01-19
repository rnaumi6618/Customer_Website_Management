/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Services;
using Invoicing.Entities;
using Assignment3Rafia.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Assignment3Rafia.Services
{
    /// <summary>
    /// Manages invoices by performing operations such as adding, updating, and retrieving customers and invoices.
    /// </summary>

    public class ManageInvoice : IManageInvoice
    {
        // Constructor injection for the DbContext
        public ManageInvoice(InvoiceDbContext invoiceDbContext)
        {
            _invoiceDbContext = invoiceDbContext;
        }


       
        // Gets a base query for customers including their invoices
        private IQueryable<Customer> GetBaseQuery()
        {
            return _invoiceDbContext.Customers
                .Include(m => m.Invoices);
        }
        

        // Retrieves all customers sorted by their names
        public ICollection<Customer> GetAllCustomer()
        {
            var customer = GetBaseQuery()
               .OrderBy(m => m.Name).ToList();

            return customer;
        }

        //// Retrieves all customers sorted by their names

        public ICollection<Customer> GetCustomersByGroup(string lowerBound, string upperBound)
        {
            lowerBound = lowerBound.ToLower();
            upperBound = upperBound.ToLower();

            return GetAllCustomer()
                .Where(c => !c.IsDeleted &&
                            c.Name.ToLower().Substring(0, 1).CompareTo(lowerBound) >= 0 &&
                            c.Name.ToLower().Substring(0, 1).CompareTo(upperBound) <= 0)
                .OrderBy(c => c.Name)
                .ToList();
        }

        // Retrieves a customer by their unique ID
        public Customer? GetCustomerById(int customerId)
        {
            return GetBaseQuery()
                    .Where(m => m.CustomerId == customerId)
                    .FirstOrDefault();

        }


        // Adds a new customer to the database.
        public int AddNewCustomer(Customer customer)
        {
            _invoiceDbContext.Customers.Add(customer);
            _invoiceDbContext.SaveChanges();
            return customer.CustomerId;
        }


        // Updates an existing customer's details.
        public void UpdateCustomer(Customer customer)
        {
            _invoiceDbContext.Customers.Update(customer);
            _invoiceDbContext.SaveChanges();
        }


        // Adds a new invoice to the database.
        public int AddNewInvoice(Invoice invoice)
        {
            _invoiceDbContext.Invoices.Add(invoice);
            _invoiceDbContext.SaveChanges();
            return invoice.InvoiceId;

        }


        // Retrieves an invoice by its unique ID
        public Invoice GetInvoiceById(int invoiceId)
        {

            return _invoiceDbContext.Invoices
                .Include(m => m.InvoiceLineItem)
               .Include(m => m.PaymentTerms).Where(i => i.InvoiceId == invoiceId).FirstOrDefault();

        }


        // Retrieves payment terms matching a specific description.
        public ICollection<PaymentTerms> GetPaymentTermsByDesc(string Description)
        {
            return _invoiceDbContext.PaymentTerms.Include(m => m.Description==Description).ToList();
        }


        // Retrieves all payment terms, sorted by description.List of PaymentTerms.
        public List<PaymentTerms> GetPaymentTerms()
        {
            return _invoiceDbContext.PaymentTerms.OrderBy(g => g.Description).ToList();
        }


        /// Retrieves all invoice line items for a specific invoice.
        public ICollection<InvoiceLineItem> GetItemByInvoice(int invoiceId)
        {
            return _invoiceDbContext.InvoicesLineItems
                .Include(m => m.InvoiceId==invoiceId).ToList();
        }



        /// Updates an existing invoice.
        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceDbContext.Invoices.Update(invoice);
            _invoiceDbContext.SaveChanges();
        }


        // Adds a new item to an invoice with The ID of the newly added invoice line item.
        public int AddNewItem(InvoiceLineItem item)
        {
            _invoiceDbContext.InvoicesLineItems.Add(item);
            _invoiceDbContext.SaveChanges();
            return item.InvoiceLineItemId;
        }

        
        //Db instance
        private InvoiceDbContext _invoiceDbContext;
    }
}
