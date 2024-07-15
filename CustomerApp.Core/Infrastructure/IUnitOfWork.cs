using CustomerApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        IGenericRepository<T, TKey> GetRepository<T, TKey>() where T : Entity<TKey>;
        Task<int> CommitAsync(CancellationToken token = default);
    }
}
