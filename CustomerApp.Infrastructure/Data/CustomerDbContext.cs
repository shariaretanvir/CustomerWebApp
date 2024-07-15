using CustomerApp.Domain.Common;
using CustomerApp.Domain.Entities;
using CustomerApp.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<IAudit>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.SetCreatedOn(DateTime.Now);
                }
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.SetModifiedOn(DateTime.Now);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerEntityConfiguration().Configure(modelBuilder.Entity<Customer>());
        }
    }
}
