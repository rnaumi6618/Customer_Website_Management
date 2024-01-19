/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Invoicing.Entities;

namespace Assignment3Rafia.Models
{
    //view model for displaying all customer of currently active group , used in Item.cshtml
    public class CustomersByGroupViewModel
    {
        public ICollection<Customer> Customers { get; set; }
        public string ActiveGroup { get; set; }
    }
}
