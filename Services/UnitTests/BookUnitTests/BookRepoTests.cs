using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Services.Models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BookUnitTests
{
    internal class BookRepoTests
    {
        private IRepository<Book> _repository;
        private AutoMocker autoMock;

        [SetUp]
        public void Setup()
        {
            autoMock = new AutoMocker();
            var lst = new List<int>();
            lst.Add(1);
            autoMock.Use(lst);
            _repository = autoMock.CreateInstance<BookRepo>();
        }

        #region SuccessfulTests

        [Test]
        public void TestSuccessfulGetBooks()
        {
            Book book = new()
            {
                ID = 1,
                Name = "Name",
                Author = "AA"
            };
            autoMock
                .Setup<StreamReader, int>(x => x.Peek())
                .Returns(1);
            autoMock
                .Setup<StreamReader, string>(x => x.ReadLine())
                .Returns("");
            //autoMock
            //    .Setup<string, Array>(x => x.Split(It.IsAny<char>()))
            //    .Returns(It.IsAny<Array>());
            var result = _repository.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Item1.Count());
            Assert.Contains(book, result.Item1.ToList());
        }
        #endregion

        #region FailTests

        [Test]
        public void TestFileNotExists_GetBooks()
        {
            var resultGet = _repository.Get();
            var resultGetByID = _repository.GetById(It.IsAny<int>());
            var resultPost = _repository.Post(It.IsAny<Book>());
            var resultPut = _repository.Put(It.IsAny<Book>());
            var resultDelete = _repository.Delete(It.IsAny<int>());

            Assert.AreEqual("There's no such file!", resultGet.Item2);
            Assert.AreEqual("There's no such file!", resultGetByID.Item2);
            Assert.AreEqual("There's no such file!", resultPost);
            Assert.AreEqual("There's no such file!", resultPut);
            Assert.AreEqual("There's no such file!", resultDelete);
        }

        [Test]
        public void TestFileNotExists_GetByIDBook()
        {
            var resultGetByID = _repository.GetById(It.IsAny<int>());
            Assert.AreEqual("There's no such file!", resultGetByID.Item2);
        }
            #endregion
        }
}
