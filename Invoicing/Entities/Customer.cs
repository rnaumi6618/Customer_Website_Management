/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Invoicing.Entities
{
    public class Customer
    {
        //pk
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Customer name is required and Must be Alphabet")]
        public string Name { get; set; }

        //mandatory address
        [Required(ErrorMessage = "Address1 is required.")]
        public string? Address1 { get; set; }

        //not mandatory
        public string? Address2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "Province or State is required.")]
        [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Province or State must be a 2-letter code.")]
        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "Zip or Postal Code is required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$|^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid Zip or Postal Code.")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }

        public string? ContactLastName { get; set; }

        public string? ContactFirstName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? ContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Navigation property to Invoices
        public ICollection<Invoice>? Invoices { get; set; }

       
    }
}
