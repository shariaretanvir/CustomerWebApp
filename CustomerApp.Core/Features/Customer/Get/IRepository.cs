using CustomerApp.Core.Common;
using CustomerApp.Core.Infrastructure;
using CustomerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Get
{
    public interface IRepository : IGenericRepository<Entities.Customer, Guid>
    {
        Task<PagedList<Entities.Customer>> GetAll(ResourceParameters resourceParameters);
    }
}
