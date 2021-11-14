using FluentValidation.Results;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Services.Mappers;
using Services.Models;
using Services.Repositories;
using Services.Validators;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class UserTests
    {
        private IRepository<User> _repository;
        private AutoMocker autoMock;
        

        [SetUp]
        public void Setup()
        {
            autoMock = new AutoMocker();
            var lst = new List<int>();
            lst.Add(1);
            autoMock.Use(lst);
            _repository = autoMock.CreateInstance<UserRepo>();
        }

        #region SuccessfulTests

        delegate void MockOutDelegate(object key, out object value);

        [Test]
        public void TestSuccessfulGetUsers()
        {
            User user = new()
            {
                Id = 1,
                Age = 1,
                Name = "Name",
                Address = "Address"
            };
            object obj;
            autoMock
            .Setup<IMemoryCache, bool>(x => x.TryGetValue(It.IsAny<object>(), out obj))
            .Callback(new MockOutDelegate((object key, out object value) => value = user))
            .Returns(true);
            var result = _repository.Get();

            Assert.AreEqual(1, result.Item1.Count());

        }

        [Test]
        public void TestSuccessfulPutUser()
        {
            var user = new User();
            autoMock
                .Setup<IUserValidator, ValidationResult>(x => x.Validate(user))
                .Returns(new ValidationResult());
            autoMock
                .Setup<IMemoryCache, ICacheEntry>(x => x.CreateEntry(It.IsAny<object>()))
                .Returns(Mock.Of<ICacheEntry>());
            var result = _repository.Put(user);

            Assert.AreEqual("Success!", result);
        }

        [Test]
        public void TestSuccessfulPostUser()
        {
            var user = new User();
            autoMock
                .Setup<IUserValidator, ValidationResult>(x => x.Validate(user))
                .Returns(new ValidationResult());
            autoMock
                .Setup<IMemoryCache, ICacheEntry>(x => x.CreateEntry(It.IsAny<object>()))
                .Returns(Mock.Of<ICacheEntry>());
            var result = _repository.Post(user);
            Assert.AreEqual("Success!", result);
        }

        [Test]
        public void TestSuccessfulDeleteUser()
        {
            var user = new User();
            object obj;
            autoMock
                .Setup<IMemoryCache, bool>(x => x.TryGetValue(It.IsAny<object>(), out obj))
                .Callback(new MockOutDelegate((object key, out object value) => value = user))
                .Returns(true);
            var result = _repository.Delete(user.Id);

            Assert.AreEqual("Success!", result);
        }

        [Test]
        public void TestSuccessfulGetByIDUser()
        {
            var user = new User();
            object obj;
            autoMock
                .Setup<IMemoryCache, bool>(x => x.TryGetValue(It.IsAny<object>(), out obj))
                .Callback(new MockOutDelegate((object key, out object value) => value = user))
                .Returns(true);
            var result = _repository.GetById(user.Id);

            Assert.AreEqual(user, result.Item1);
        }
        #endregion
        #region FailGetUsers
        [Test]
        public void TestNullReferenceCacheAllCommandsUser()
        {
            _repository = new UserRepo(null, null, null);
            User user = new();
            object obj;
            autoMock
            .Setup<IMemoryCache, bool>(x => x.TryGetValue(It.IsAny<object>(), out obj))
            .Callback(new MockOutDelegate((object key, out object value) => value = user))
            .Returns(true);
            var resultGet = _repository.Get();
            //var resultGetbyId = _repository.GetById(user.Id);
            var resultPost = _repository.Post(user);
            var resultPut = _repository.Put(user);
            var resultDelete = _repository.Delete(user.Id);

            Assert.AreEqual("Something's wrong!", resultGet.Item2);
            //Assert.AreEqual("Something's wrong!", resultGetbyId.Item2);
            Assert.AreEqual("Something's wrong!", resultPost);
            Assert.AreEqual("Something's wrong!", resultPut);
            Assert.AreEqual("Something's wrong!", resultDelete);
        }

        [Test]
        public void TestNullReferenceCacheGetUsers()
        {
            _repository = new UserRepo(null, null, null);
            var resultGet = _repository.Get();

            Assert.AreEqual("Something's wrong!", resultGet.Item2);
        }

        [Test]
        public void TestNullReferenceCacheGetByIdUser()
        {
            _repository = new UserRepo(null, null, null);
            User user = new();
            object obj;

            autoMock
                .Setup<IMemoryCache, User>(x => x.Get<User>(user.Id))
                .Returns(user);
            autoMock
            .Setup<IMemoryCache, bool>(x => x.TryGetValue(It.IsAny<object>(), out obj))
            .Callback(new MockOutDelegate((object key, out object value) => value = user))
            .Returns(true);
            var resultGetbyId = _repository.GetById(user.Id);

            Assert.AreEqual("Something's wrong!", resultGetbyId.Item2);
        }
        #endregion
    }
}