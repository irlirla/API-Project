using FranchiseService.Broker.Requests;
using FranchiseService.Models;

namespace FranchiseService.Mapper
{
    public class FranchisePostRequestToFranchise : IMapper<FranchisePostRequest, Franchise>
    {
        public Franchise Map(FranchisePostRequest fran)
        {
            if (fran is null)
            {
                return null;
            }
            else
            {
                return new Franchise { FranchiseID = fran.FranchiseID, Name = fran.Name };
            }
        }
    }
}
