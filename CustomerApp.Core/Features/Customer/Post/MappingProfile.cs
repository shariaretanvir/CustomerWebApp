using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Features.Customer.Post
{
    public class MappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PostCustomerCommand, Entities.Customer>()
                .IgnoreNonMapped(true)
                .ConstructUsing(src => new Entities.Customer(
                        src.Id,
                        src.Name,
                        src.Age,
                        src.IsActive
                    ));
        }
    }
}
