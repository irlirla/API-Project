using System.Collections.Generic;

namespace FranchiseService.Models
{
    public class FranchiseDTO
    {
        public string Name { get; init; }
        public ICollection<Movie> Movies { get; set; }
    }
}
