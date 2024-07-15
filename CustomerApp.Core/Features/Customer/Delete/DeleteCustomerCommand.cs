using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Delete
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}
