using Services.Models;

namespace Services.Mappers
{
    public class FranchiseToFranchiseDTO : IMapper<Franchise, FranchiseDTO>
    {
        public FranchiseDTO Map(Franchise fran)
        {
            if (fran is null)
            {
                return null;
            }
            else
            {
                return new FranchiseDTO { Name = fran.Name, Movies = fran.Movies };
            }
        }
    }
}
