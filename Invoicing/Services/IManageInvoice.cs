using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Entities;
using Invoicing.Services;

namespace Invoicing.Services
{
    // <summary>
    /// Defines the contract for managing invoices including operations for customers, invoices, and payment terms.
    /// </summary>
    public interface IManageInvoice
    {
        // Retrieves a collection of all customers from the db
        public ICollection<Customer> GetAllCustomer();

        //Retrieves a collection of all customers of a specific group
        public ICollection<Customer> GetCustomersByGroup(string lowerBound, string upperBound);

        // Adds a new customer to the db and returns the newly created customer's ID
        public int AddNewCustomer(Customer customer);
        // Retrieves a customer by their unique ID, returns null if the customer does not exist
        public Customer? GetCustomerById(int customerId);

        // Updates the information of an existing customer
        public void UpdateCustomer(Customer customer);

        // Adds a new invoice to the system and returns the newly created invoice's ID
        public int AddNewInvoice(Invoice invoice);

        // Retrieves a collection of PaymentTerms that match a given description
        public ICollection<PaymentTerms> GetPaymentTermsByDesc(string Description);

        // Retrieves a list of all PaymentTerms, sorted by their description
        public List<PaymentTerms> GetPaymentTerms();

        // Retrieves a specific invoice by its ID, returns null if the invoice does not exist
        public Invoice GetInvoiceById(int invoiceId);

        // Retrieves all line items associated with a specific invoice ID
        public ICollection<InvoiceLineItem> GetItemByInvoice(int invoiceId);

        // Updates the details of an existing invoice
        public void UpdateInvoice(Invoice invoice);
        
        // Adds a new line item to an invoice and returns the ID of the newly added item
        public int AddNewItem(InvoiceLineItem item);

        //public List<Invoice> GetInvoicesByCustomerId(int customerId);
    }
}
