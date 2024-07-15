using CustomerApp.Core.Infrastructure;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Put
{
    public class PutCustomerHandler : IRequestHandler<PutCustomerCommand, PutCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PutCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PutCustomerResponse> Handle(PutCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.GetRepository<Entities.Customer, Guid>().GetByIdAsync(request.Id);

            if (customer != null)
            {
                _mapper.Map(request, customer);
                _unitOfWork.GetRepository<Entities.Customer, Guid>().Update(customer);
                if (await _unitOfWork.CommitAsync() > 0)
                {
                    return new PutCustomerResponse { IsUpdated = true, IsExists = true };
                }
                else
                {
                    return new PutCustomerResponse { IsUpdated = false, IsExists = true };
                }
            }
            else
            {
                return new PutCustomerResponse { IsUpdated = false, IsExists = false };
            }

        }
    }
}
