/* Assignment3.cs
 * Invoice Management Webpage
 * Revision History: 1.12.23-10.12.23
 * Rafia Naumi
 * 10.12.23
 */
using Assignment3Rafia.Models;
using Assignment3Rafia.TagHelpers;
using Invoicing.Entities;
using Invoicing.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment3Rafia.Controllers
{
    public class InvoiceManageController : Controller
    {
        // Constructor for initializing with IManageInvoice service
        public InvoiceManageController(IManageInvoice manageinvoice)
        {
            _manageinvoice = manageinvoice;
        }

        // Gets a list of customers within a specified group range
        [HttpGet("/invoiceManage/GetCustomersByGroup/{lowerBound}-{upperBound}")]
        public IActionResult GetCustomersByGroup(string lowerBound, string upperBound)
        {
            // Query to filter customers by name within specified alphabetical range if it is not deleted
            var customers = _manageinvoice.GetCustomersByGroup(lowerBound, upperBound);
            // view model with filtered customers and active group
            var customersByGroupViewModel = new CustomersByGroupViewModel
            {
                Customers = customers,
                ActiveGroup = $"{lowerBound.ToUpper()} - {upperBound.ToUpper()}"
            };

            //store the current group in temp data
            TempData["CurrentGroup"] = $"{lowerBound}-{upperBound}";

            return View("Items", customersByGroupViewModel);
        }


        // Renders the form to add a new customer
        [HttpGet("/invoiceManage/add-request")]
        [Authorize()]
        public IActionResult GetAddCustomerRequest()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                ActiveCustomer = new Customer()
            };
            return View("Add",customerViewModel);
        }

        // Processes the addition of a new customer
        [HttpPost("/invoiceManage/addcustomer")]
        [Authorize()]
        public IActionResult GetAddCustomer(CustomerViewModel customerViewModel)
        {
            // If model is valid, add the new customer and set success message
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new customer to the DB:
                _manageinvoice.AddNewCustomer(customerViewModel.ActiveCustomer);
                TempData["LastActionMessage"] = $"Customer \"{customerViewModel.ActiveCustomer.Name}\" was added.";

                // Retrieve the current group from TempData
                string currentGroup = TempData["CurrentGroup"] as string;
                var parts = currentGroup.Split('-');

                // Redirecting back to the customer list within the same group range
                return RedirectToAction("GetCustomersByGroup","InvoiceManage", new { lowerBound = parts[0], upperBound = parts[1] });
            }
            else
            {
                // it's invalid so we simply return the customer object
                // to the Add view again:
                ModelState.AddModelError("", "There are error in the form please fix them and try again");
                return View("Add", customerViewModel);
            }
        }


        // Renders the form to edit an existing customer
        [HttpGet("/invoiceManage/{id}/edit-request")]
        [Authorize()]
        public IActionResult GetEditRequestById(int id)
        {
            // Fetching the customer by ID to pre-fill in the edit form
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                ActiveCustomer = _manageinvoice.GetCustomerById(id)
            };

            return View("Edit", customerViewModel);
        }

        // Processes the editing of an existing customer
        [HttpPost("/invoiceManage/edit-requests")]
        [Authorize()]
        public IActionResult ProcessEditRequest(CustomerViewModel customerViewModel)
        {
            // If model is valid, update the customer and set success message
            if (ModelState.IsValid)
            {
                _manageinvoice.UpdateCustomer(customerViewModel.ActiveCustomer);
                TempData["LastActionMessage"] = $"The customer \"{customerViewModel.ActiveCustomer.Name}\" was updated.";

                // Retrieve the current group from TempData
                string currentGroup = TempData["CurrentGroup"] as string;
                var parts = currentGroup.Split('-');

                // Redirecting back to the customer list within the same group range
                return RedirectToAction("GetCustomersByGroup", "InvoiceManage", new { lowerBound = parts[0], upperBound = parts[1] });
            }
            else
            {
                // If model is invalid, return to the form
                // with the existing data and error message
                ModelState.AddModelError("", "There are error in the form please fix them and try again");
                return View("Edit", customerViewModel);
            }
        }

        // Processes the deletion of a customer
        [HttpGet("/invoiceManage/{id}/delete-request")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDeleteRequestById(int id)
        {
            var customer = _manageinvoice.GetCustomerById(id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                _manageinvoice.UpdateCustomer(customer);
                TempData["LastActionMessage"] = $"The customer \"{customer.Name}\" is deleted.";
                TempData["UndoCustomerId"] = customer.CustomerId;
            }

            string currentGroup = TempData["CurrentGroup"] as string;
            var parts = currentGroup.Split('-');
            return RedirectToAction("GetCustomersByGroup", "InvoiceManage", new { lowerBound = parts[0], upperBound = parts[1] });
        }

        // // Processes the undo of delete
        [HttpGet("/invoiceManage/UndoDeleteCustomer/{id}")]
        public IActionResult UndoDeleteCustomer(int id)
        {
            var customer = _manageinvoice.GetCustomerById(id);
            if (customer != null)
            {
                customer.IsDeleted = false;
                _manageinvoice.UpdateCustomer(customer);
            }
            // Retrieve the current group from TempData
            string currentGroup = TempData["CurrentGroup"] as string;
            var parts = currentGroup.Split('-');
            return RedirectToAction("GetCustomersByGroup", "InvoiceManage", new { lowerBound = parts[0], upperBound = parts[1] });
        }

        
        // Gets a list of invoices of a specific customer by id
        [HttpGet("/invoiceManage/GetInvoiceByCustomers/{id}")]
        public IActionResult GetInvoiceByCustomers(int id)
        {
            var customer = _manageinvoice.GetCustomerById(id);
            if (customer.Invoices == null) {
                customer.Invoices = new List<Invoice>();
            }
            var payTerms= _manageinvoice.GetPaymentTerms();

            InvoiceByCustomerViewModel invoiceByCustomerViewModel = new InvoiceByCustomerViewModel
            {
                //Invoice = invoice,
                payTerms = payTerms,
                ActiveCustomer = customer,
                Group = TempData["CurrentGroup"] as string
            };
            return View("Item", invoiceByCustomerViewModel);
        }

        //process a new addition of invoice of a specific customer by id
        [HttpPost("/invoiceManage/invoice/{id}")]
        public IActionResult AddInvoiceToCustomerById(int id, InvoiceByCustomerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Query for the course by the ID But need to include students
                var customer = _manageinvoice.GetCustomerById(id);

                Invoice invoice = vm.NewInvoice;
                invoice.CustomerId = id;
                invoice.Customer = customer;
                _manageinvoice.AddNewInvoice(invoice);
                _manageinvoice.UpdateCustomer(customer);

                // Redirect back to that same Manage page
                return RedirectToAction("GetInvoiceByCustomers", "InvoiceManage", new { id = customer.CustomerId });
            }
            
            return RedirectToAction("GetInvoiceByCustomers", "InvoiceManage", new { id =id });
        }

        // Gets a list of items of a specific invoice by id
        [HttpGet("/invoiceManage/GetItemsByInvoiceId/{id}")]
        public IActionResult GetItemsByInvoiceId(int id)
        {
            var invoice = _manageinvoice.GetInvoiceById(id); 
            var customer = _manageinvoice.GetCustomerById(invoice.CustomerId); 
            var payTerms = _manageinvoice.GetPaymentTerms();
            InvoiceByCustomerViewModel viewModel = new InvoiceByCustomerViewModel
            {
                payTerms = payTerms,
                ActiveCustomer = customer,
                ActiveInvoice = invoice,
                SelectedInvoiceId = invoice.InvoiceId,
                InvoiceItems = invoice.InvoiceLineItem.ToList(),
                Total= invoice.InvoiceLineItem.Sum(item => item.Amount) ?? 0
            };

            return View("Item", viewModel);
        }

        //process a new addition of item of a specific invoice by id
        [HttpPost("/invoiceManage/invoice/item/{id}")]
        public IActionResult AddItemToInvoiceById(int id, InvoiceByCustomerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Query for the course by the ID But need to include students
                var invoice = _manageinvoice.GetInvoiceById(id);

                InvoiceLineItem item = vm.NewItem;
                item.InvoiceId = id;
                item.Invoice = invoice;
                _manageinvoice.AddNewItem(item);
                _manageinvoice.UpdateInvoice(invoice);

                // Redirect back to that same Manage page
                return RedirectToAction("GetItemsByInvoiceId", "InvoiceManage", new { id = invoice.InvoiceId });
            }
            // Redirect back to that same Manage page
            return RedirectToAction("GetItemsByInvoiceId", "InvoiceManage", new { id=id });
        }

        
        private IManageInvoice _manageinvoice;
    }
}
