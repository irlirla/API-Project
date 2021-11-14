using Moq;
using NUnit.Framework;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BookUnitTests
{
    internal class BookMapperTest
    {
        private BookToBookDTO _mapper;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mapper = new BookToBookDTO();
        }

        [Test]
        public void SuccessfulMapBook_Test()
        {
            Book book = new()
            {
                ID = 1,
                Name = "Name",
                Author = "Author"
            };
            BookDTO bookdto = new()
            {
                Name = book.Name,
                Author = book.Author
            };

            var result = _mapper.Map(book);
            Assert.AreEqual(bookdto.Name, result.Name);
            Assert.AreEqual(bookdto.Author, result.Author);
        }

        [Test]
        public void FailMapBook_Test()
        {
            Book book = new()
            {
                ID = 1,
                Name = "Name",
                Author = "Author"
            };

            var result = _mapper.Map(book);
            Assert.AreNotEqual(It.IsAny<BookDTO>(), result);
        }
    }
}
