using FranchiseService.Models;
using FranchiseService.Validator;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FranchiseService.Repositories
{
    public class FranchiseRepo : IAsyncRepository<Franchise>
    {
        DbTheatreContext Theatre = new();
        const string str1 = "Success!";
        const string str2 = "Something went wrong!";
        private readonly IFranchiseValidator _validator;

        public FranchiseRepo(IFranchiseValidator validator)
        {
            _validator = validator;
        }

        public async Task<string> Delete(int id)
        {
            var franchise = await Theatre.Franchises.SingleAsync(x => x.FranchiseID == id);
            Theatre.Remove(franchise);
            await Theatre.SaveChangesAsync();
            return str1;
        }

        public async Task<IEnumerable<Franchise>> Get()
        {
            IAsyncEnumerable<Franchise> franchises = Theatre.Franchises.AsAsyncEnumerable();
            List<Franchise> franchises1 = await franchises.ToListAsync();
            return franchises1;
        }

        public async Task<Franchise> GetById(int id)
        {
            IAsyncEnumerable<Franchise> franchises = Theatre.Franchises.AsAsyncEnumerable().Where(x => x.FranchiseID == id);
            List<Franchise> franchises1 = await franchises.ToListAsync();
            return franchises1[0];
        }

        public async Task<string> Post(Franchise franchise)
        {
            if (_validator.Validate(franchise).IsValid is true &&
                await Theatre.Franchises.AnyAsync(x => x.FranchiseID == franchise.FranchiseID) is false)
            {
                await Theatre.Franchises.AddAsync(new Franchise());
                await Theatre.SaveChangesAsync();
                return str1;
            }
            else
            {
                return str2;
            }
        }

        public async Task<string> Put(Franchise franchise)
        {
            if (_validator.Validate(franchise).IsValid is true)
            {
                await Theatre.Franchises.AddAsync(new Franchise());
                await Theatre.SaveChangesAsync();
                return str1;
            }
            else
            {
                return str2;
            }
        }
    }
}
