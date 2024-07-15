using CustomerApp.Core.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Delete
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.GetRepository<Entities.Customer, Guid>().GetByIdAsync(request.Id);
            if (customer != null)
            {
                _unitOfWork.GetRepository<Entities.Customer, Guid>().Delete(customer);
                
                if (await _unitOfWork.CommitAsync() > 0)
                {
                    return new DeleteCustomerResponse { IsDeleted = true, IsExists = true };
                }
                else
                {
                    return new DeleteCustomerResponse { IsDeleted = false, IsExists = true };
                }
            }
            else
            {
                return new DeleteCustomerResponse { IsDeleted = false, IsExists = false };
            }
        }
    }
}
