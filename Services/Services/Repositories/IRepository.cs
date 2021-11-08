using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        void Post(T t);
        void Put(T t);
        void Delete(int id);
    }
}
