using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Post
{
    public class PostCustomerCommandValidator : AbstractValidator<PostCustomerCommand>
    {
        public PostCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Age).NotNull().NotEmpty();
        }
    }
}
