using CustomerApp.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.UI.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public DeleteModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            try
            {
                await _apiService.DeleteAsync("https://localhost:7180/api/customer/DeleteCustomer?id=" + id);
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
