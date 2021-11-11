using Services.Models;
using System.Collections.Generic;

namespace FranchiseService.Models
{
    public class FranchiseDTO
    {
        public string Name { get; init; }
        public List<Movie> Movies { get; set; }
    }
}
