using CustomerApp.UI.Models;
using CustomerApp.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.UI.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly ApiService _apiService;
        public List<GetCustomerModel> Customers { get; set; }
        public PaginationMetaData PaginationMetaData { get; set; }

        public CustomersModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var response  = await _apiService.GetApiDataAsync<APIResponse<CustomerListModel>>("https://localhost:7180/api/customer/GetCustomers?PageNumber=1&PageSize=50");

                Customers = response.data!.customerModel;
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
