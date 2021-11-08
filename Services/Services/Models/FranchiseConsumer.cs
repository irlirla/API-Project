using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class FranchiseConsumer : IConsumer<FranchiseRequest>
    {
        public async Task Consume(ConsumeContext<FranchiseRequest> context)
        {
            await context.RespondAsync(new FranchiseDTO { Name = "" });
        }
    }
}
