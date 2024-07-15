using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Put
{
    public class PutCustomerResponse
    {
        public bool IsUpdated { get; set; }
        public bool IsExists { get; set; }
    }
}
