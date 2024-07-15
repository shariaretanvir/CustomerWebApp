using CustomerApp.Core.Common;
using CustomerApp.Core.Features.Customer.Get;
using CustomerApp.Domain.Entities;
using CustomerApp.Infrastructure.Common;
using CustomerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, Guid>, IRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<Customer>> GetAll(ResourceParameters resourceParameters)
        {
            IQueryable<Customer> query = _dbContext.Set<Customer>();
            return PagedList<Customer>.Create(await query.ToListAsync(), resourceParameters.PageNumber, resourceParameters.PageSize);
        }
    }
}
