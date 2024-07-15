using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Get
{
    public class GetCustomerRequest : IRequest<GetCustomerResponse>
    {
        public ResourceParameters ResourceParameters { get; set; }
    }
}
