using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Commands.Interfaces
{
    public interface IDeleteCommand<T>
    {
        void Execute(int i);
    }
}
