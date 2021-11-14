using System.Collections.Generic;

namespace Services.Models
{
    public class FranchiseDTO
    {
        public string Name { get; init; }
        public List<Movie> Movies { get; set; }
    }
}
