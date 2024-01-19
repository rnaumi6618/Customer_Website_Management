/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Entities;
namespace Assignment3Rafia.Models
{
    //view model for EDit and Add page only
    public class CustomerViewModel
    {
        public Customer ActiveCustomer { get; set; }

        public string ActiveGroup;
    }
}
