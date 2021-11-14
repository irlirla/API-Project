using FluentValidation.TestHelper;
using NUnit.Framework;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieUnitTests
{
    internal class MovieValidationTest
    {
        private MovieValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new MovieValidator();
        }

        [Test]
        public void ValidMovieRequest_Test()
        {
            Movie movie = new()
            {
                ID = 1,
                Name = "Name",
                FranchiseName =
                {
                    FranchiseID = 1,
                    Name = "NameF"
                }
            };

            TestValidationResult<Movie> result = _validator.TestValidate(movie);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidMovieRequest_Test()
        {
            Movie movie = new()
            {
                ID = -1,
                FranchiseName =
                {
                    FranchiseID = -1,
                    Name = "Franchise"
                }
            };

            TestValidationResult<Movie> result = _validator.TestValidate(movie);
            result.ShouldHaveValidationErrorFor(x => x.ID);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.FranchiseName.FranchiseID);
            result.ShouldHaveValidationErrorFor(x => x.FranchiseName.Name);
        }
    }
}
