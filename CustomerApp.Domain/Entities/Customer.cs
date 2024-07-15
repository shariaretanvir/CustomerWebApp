using CustomerApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Domain.Entities
{
    public class Customer : Entity<Guid>, IAudit
    {
        public override Guid Id { get; protected set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }


        public Customer(Guid id, string name, int age, bool isActive)
        {
            Id = id;
            Name = name;
            Age = age;
            IsActive = isActive;
        }

        #region audit
        public DateTime CreatedOn { get; private set; }

        public DateTime ModifiedOn { get; private set; }

        public void SetCreatedOn(DateTime createdOn)
        {
            CreatedOn = createdOn;
        }

        public void SetModifiedOn(DateTime modifiedOn)
        {
            ModifiedOn = modifiedOn;
        }
        #endregion
    }
}
