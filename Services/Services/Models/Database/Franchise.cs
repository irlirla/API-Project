using Services.Models;
using System.Collections.Generic;

namespace Services.Models
{
    public class Franchise
    {
        public int FranchiseID { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
