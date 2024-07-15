using CustomerApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Get
{
    public record GetCustomerResponse(List<GetCustomerModel> customerModel, PaginationMetaData PaginationMetaData);
}
