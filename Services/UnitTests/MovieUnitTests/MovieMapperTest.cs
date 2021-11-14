using Moq;
using NUnit.Framework;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieUnitTests
{
    internal class MovieMapperTest
    {
        private MovieToMovieDTO _mapper;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new MovieToMovieDTO();
        }

        [Test]
        public void SuccessfulMapMovie_Test()
        {
            Movie movie = new()
            {
                ID = 1,
                Name = "Name",
                FranchiseName =
                {
                    FranchiseID = 1,
                    Name = "Fran"
                }
            };
            MovieDTO moviedto = new()
            {
                Name = movie.Name,
                FranchiseName = movie.FranchiseName.Name
            };

            var result = _mapper.Map(movie);
            Assert.AreEqual(moviedto.Name, result.Name);
            Assert.AreEqual(moviedto.FranchiseName, result.FranchiseName);
        }

        [Test]
        public void FailMapMovie_Test()
        {
            Movie movie = new()
            {
                ID = 1,
                Name = "Name",
                FranchiseName =
                {
                    FranchiseID = 1,
                    Name = "Fran"
                }
            };

            var result = _mapper.Map(movie);
            Assert.AreNotEqual(It.IsAny<MovieDTO>(), result);
        }
    }
}
