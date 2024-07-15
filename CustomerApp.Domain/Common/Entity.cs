using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Domain.Common
{
    public abstract class Entity<TId>
    {
        public abstract TId Id { get; protected set; }
    }
}
