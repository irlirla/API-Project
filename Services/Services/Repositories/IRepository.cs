using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IRepository<T>
    {
        (IEnumerable<T>, string) Get();
        (T, string) GetById(int id);
        string Post(T t);
        string Put(T t);
        string Delete(int id);
    }
}
