﻿using System.Collections.Generic;

namespace FranchiseService.Models
{
    public class Franchise
    {
        public int FranchiseID { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
