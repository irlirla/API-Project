using Services.Models;
using System.Collections.Generic;

namespace FranchiseService.Models
{
    public class Franchise
    {
        public int FranchiseID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
