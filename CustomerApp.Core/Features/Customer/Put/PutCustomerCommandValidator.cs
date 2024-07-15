using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Put
{
    public class PutCustomerCommandValidator : AbstractValidator<PutCustomerCommand>
    {
        public PutCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Age).NotNull().NotNull();
        }
    }
}
