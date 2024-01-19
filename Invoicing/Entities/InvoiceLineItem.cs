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
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }

        public double? Amount { get; set; }

        
        public string? Description { get; set; }

        // Navigation property to Invoice
        public  Invoice? Invoice { get; set; }

        // FK:
        public int? InvoiceId { get; set; }
    }
}
