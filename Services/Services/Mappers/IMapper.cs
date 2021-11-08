using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public interface IMapper<in i, out o>
    {
        o Map(i item);
    }
}
