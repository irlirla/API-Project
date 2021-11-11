﻿using MassTransit;
using System.Threading.Tasks;

namespace FranchiseService.Models
{
    public class FranchiseConsumer : IConsumer<FranchiseRequest>
    {
        public async Task Consume(ConsumeContext<FranchiseRequest> context)
        {
            await context.RespondAsync(new FranchiseDTO { Name = "" });
        }
    }
}