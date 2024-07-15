using CustomerApp.Core.Infrastructure;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Post
{
    public class PostCustomerHandler : IRequestHandler<PostCustomerCommand, PostCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostCustomerHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PostCustomerResponse> Handle(PostCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Entities.Customer>(command);
            await _unitOfWork.GetRepository<Entities.Customer, Guid>().AddAsync(customer);

            if (await _unitOfWork.CommitAsync() > 0)
            {
                return new PostCustomerResponse { IsAdded = true };
            }
            else
            {
                return new PostCustomerResponse { IsAdded = false };
            }
        }
    }
}
