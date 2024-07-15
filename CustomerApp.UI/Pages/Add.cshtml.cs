using CustomerApp.UI.Models;
using CustomerApp.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace CustomerApp.UI.Pages
{
    public class AddModel : PageModel
    {
        private readonly ApiService _apiService;

        public AddModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public PostCustomer Data { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _apiService.PostAsync<PostCustomer>("https://localhost:7180/api/customer/SaveCustomer", Data);
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
