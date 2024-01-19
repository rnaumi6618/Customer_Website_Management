/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Entities;

namespace Assignment3Rafia.Models
{
    //viewmodel for the invoices and items of a specific customer, used in item.cshtml
    public class InvoiceByCustomerViewModel
    {
        // A list of payment terms
        public List<PaymentTerms>? payTerms { get; set; }

        // The currently active customer
        public Customer? ActiveCustomer { get; set; }

        // Represents a new invoice being created
        public Invoice? NewInvoice { get; set; }

        // Represents a new line item being added to an invoice
        public InvoiceLineItem? NewItem { get; set; }

        // The currently active invoice
        public Invoice? ActiveInvoice { get; set; }

        // A list of line items for a specific invoice
        public List<InvoiceLineItem>? InvoiceItems { get; set; }

        // Represents the total amount or value
        public double Total;

        // A string to represent a group of alphabet
        public string Group;

        // Stores the ID of the selected invoice
        public int SelectedInvoiceId { get; set; }


    }
}
