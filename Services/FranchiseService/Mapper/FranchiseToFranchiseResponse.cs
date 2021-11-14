using FranchiseService.Models;

namespace FranchiseService.Mapper
{
    public class FranchiseToFranchiseResponse : IMapper<Franchise, FranchiseResponse>
    {
        public FranchiseResponse Map(Franchise fran)
        {
            if (fran is null)
            {
                return null;
            }
            else
            {
                return new FranchiseResponse { Name = fran.Name};
            }
        }
    }
}
