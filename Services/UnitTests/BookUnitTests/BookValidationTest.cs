using FluentValidation.TestHelper;
using NUnit.Framework;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BookUnitTests
{
    internal class BookValidationTest
    {
        private BookValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new BookValidator();
        }

        [Test]
        public void ValidUserRequest_Test()
        {
            Book book = new()
            {
                ID = 1,
                Name = "Name",
                Author = "Ya"
            };

            TestValidationResult<Book> result = _validator.TestValidate(book);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidBookRequest_Test()
        {
            Book book = new()
            {
                ID = -1,
                Author = "Author"
            };

            TestValidationResult<Book> result = _validator.TestValidate(book);
            result.ShouldHaveValidationErrorFor(x => x.Author);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.ID);
        }
    }
}
