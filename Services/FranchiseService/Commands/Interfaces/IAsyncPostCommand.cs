using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseService.Commands.Interfaces
{
    public interface IAsyncPostCommand<T>
    {
        Task Execute(T t);
    }
}
