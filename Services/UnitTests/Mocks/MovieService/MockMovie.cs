using Services.Models;
using System.Collections.Generic;

namespace UnitTests.Mocks.MovieService
{
    public class MockMovie
    {
        List<Movie> mockMovieList = new()
        {
            new Movie { ID = 1, Name = "IT", FranchiseName = "IT" },
            new Movie { ID = 2, Name = "IT Two", FranchiseName = "IT" },
            new Movie { ID = 3, Name = "HP and the Chanmer of Secrets", FranchiseName = "Harry Potter" },
            new Movie { ID = 4, Name = "HP and the Goblet of Fire", FranchiseName = "Harry Potter" },
            new Movie { ID = 5, Name = "The Hunger Games", FranchiseName = "Hunger Games" },
            new Movie { ID = 6, Name = "Catching Fire", FranchiseName = "Hunger Games" },
            new Movie { ID = 7, Name = "Shaun of the Dead", FranchiseName = "Blood and Ice Cream" }
        };

        Movie mockMovie = new() { ID = 7, Name = "Shaun of the Dead", FranchiseName = "Blood and Ice Cream" };
    }
}
