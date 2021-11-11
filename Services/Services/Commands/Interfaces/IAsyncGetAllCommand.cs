using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Commands.Interfaces
{
    public interface IAsyncGetAllCommand<T>
    {
        Task<IEnumerable<T>> Execute();
    }
}
