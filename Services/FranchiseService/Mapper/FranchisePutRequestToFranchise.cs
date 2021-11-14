using FranchiseService.Broker.Requests;
using FranchiseService.Models;

namespace FranchiseService.Mapper
{
    public class FranchisePutRequestToFranchise : IMapper<FranchisePutRequest, Franchise>
    {
        public Franchise Map(FranchisePutRequest fran)
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
