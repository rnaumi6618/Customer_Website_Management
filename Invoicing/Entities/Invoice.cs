/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Entities;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.Entities
{
    public class Invoice
    {
        //pk
        public int InvoiceId { get; set; }

       
        public DateTime? InvoiceDate { get; set; }

        //add payment terms with invoice date
        public DateTime? InvoiceDueDate
        {
            get
            {
                return InvoiceDate?.AddDays(Convert.ToDouble(PaymentTerms?.DueDays));
            }
        }

        public double? PaymentTotal { get; set; } = 0.0;

        public DateTime? PaymentDate { get; set; }

        // FK:

        public int PaymentTermsId { get; set; }

        // Navigation property to Payment Terms
        public PaymentTerms? PaymentTerms { get; set; }

        // FK:
        public int CustomerId { get; set; }
        // Navigation property to Customer
        public Customer? Customer { get; set; }

        // Navigation property to Line Items
        public ICollection<InvoiceLineItem>? InvoiceLineItem { get; set; }
        //public ICollection<PaymentTerms>? payTerms { get; set; }


    }
}
