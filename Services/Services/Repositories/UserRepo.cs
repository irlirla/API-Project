using Microsoft.Extensions.Caching.Memory;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Repositories
{
    public class UserRepo : IRepository<User>
    {
        public const string str1 = "Success!";
        public const string str2 = "Something's wrong!";

         
        private IMemoryCache _cache;
        private List<int> _key;
        private readonly IUserValidator _validator;

        public UserRepo(IMemoryCache cache, List<int> key, IUserValidator validator)
        {
            _cache = cache;
            _key = key;
            _validator = validator;
        }

        public string Delete(int id)
        {
            if (_cache.Get<User>(id) is not null)
            {
                _cache.Remove(id);
                _key.Remove(id);
                return str1;
            }
            else
            {
                return str2;
            }
        }

        public (IEnumerable<User>, string) Get()
        {
            List<User> users = new();
            if (_cache is not null)
            {
                foreach (int k in _key)
                {
                    users.Add(_cache.Get<User>(k));
                }
                return (users, str1);
            }
            else return (users, str2);
        }

        public (User, string) GetById(int id)
        {
            if (_cache.Get<User>(id) is not null)
            {
                return (_cache.Get<User>(id), str1);
            }
            else
            {
                return (new User(), str2);
            }
        }

        public string Post(User user)
        {
            if (user is not null && _cache.Get<User>(user.Id) is null && _validator.Validate(user).IsValid)
            {
                _cache.Set(user.Id, user);
                _key.Add(user.Id);
                return str1;
            }
            else
            {
                return str2;
            }
        }

        public string Put(User user)
        {
            if (user is not null && _validator.Validate(user).IsValid)
            {
                _cache.Set(user.Id, user);
                return str1;
            }
            else
            {
                return str2;
            }
        }
    }
}
