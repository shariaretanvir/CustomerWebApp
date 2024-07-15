using CustomerApp.Core.Common;
using CustomerApp.Core.Infrastructure;
using CustomerApp.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Get
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly ILogger<GetCustomerHandler> _logger;        
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetCustomerHandler(ILogger<GetCustomerHandler> logger, IMapper mapper, IRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAll(request.ResourceParameters);
            return new GetCustomerResponse(_mapper.Map<List<GetCustomerModel>>(data.Items), _mapper.Map<PaginationMetaData>(data));
        }
    }
}
