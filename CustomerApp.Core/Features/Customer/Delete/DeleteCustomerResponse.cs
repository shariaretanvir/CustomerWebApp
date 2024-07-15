using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Delete
{
    public class DeleteCustomerResponse
    {
        public bool IsDeleted { get; set; }
        public bool IsExists { get; set; }
    }
}
