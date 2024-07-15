using CustomerApp.UI.Models;
using CustomerApp.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.UI.Pages
{
    public class EditCustomerModel : PageModel
    {
        private readonly ApiService _apiService;

        public EditCustomerModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public PutCustomer Customer { get; set; }

        public IActionResult OnGet(Guid? id, string name, int age, bool isActive)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = new PutCustomer
            {
                Id = id.Value,
                Name = name,
                Age = age,
                IsActive = isActive
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _apiService.PutAsync<PutCustomer>("https://localhost:7180/api/customer/UpdateCustomer", Customer);
                return RedirectToPage("/Customers");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while submitting the data.");
                return Page();
            }
            
        }
    }
}
