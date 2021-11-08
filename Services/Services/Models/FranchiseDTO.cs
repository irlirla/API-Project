using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class FranchiseDTO
    {
        public string Name { get; init; }
        public List<Movie> Movies { get; set; }
    }
}
