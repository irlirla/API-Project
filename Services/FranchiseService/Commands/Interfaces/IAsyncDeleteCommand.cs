using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseService.Commands.Interfaces
{
    public interface IAsyncDeleteCommand<T>
    {
        Task Execute(int i);
     }
}
