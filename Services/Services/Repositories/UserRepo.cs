using Microsoft.Extensions.Caching.Memory;
using Services.Models;
using System;
using System.Collections.Generic;

namespace Services.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private IMemoryCache _cache;
        private List<int> _key;

        public UserRepo(IMemoryCache cache, List<int> key)
        {
            _cache = cache;
            _key = key;
        }

        public void Delete(int id)
        {
            if (_cache.Get(id) is not null)
            {
                _cache.Remove(id);
                _key.Remove(id);
            }
            else
            {
                //no such user
            }
        }

        public IEnumerable<User> Get()
        {
            List<User> users = new();
            foreach (int k in _key)
            {
                users.Add(_cache.Get<User>(k));
            }
            return users;
        }

        public User GetById(int id)
        {
            if (_cache.Get<User>(id) is not null)
            {
                return _cache.Get<User>(id);
            }
            else
            {
                return _cache.Get<User>(id);
                //no such user
            }
        }

        public void Post(User user)
        {
            if (user is not null && _cache.Get<User>(user.Id) is null)
            {
                _cache.Set(user.Id, user);
                _key.Add(user.Id);
            }
            else
            {
                //id taken
            }
        }

        public void Put(User user)
        {
            if (user is not null)
            {
                _cache.Set(user.Id, user);
                _key.Add(user.Id);
            }
        }
    }
}
