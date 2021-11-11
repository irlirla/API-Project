using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranchiseService
{
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<string> Post(T t);
        Task<string> Put(T t);
        Task<string> Delete(int id);
    }
}
