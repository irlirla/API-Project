using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Commands.Interfaces
{
    public interface IPutCommand<T>
    {
        void Execute(T t);
    }
}
