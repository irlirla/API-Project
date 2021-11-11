using Services.Models;
using System.Collections.Generic;

namespace UnitTests.Mocks.UserService
{
    public class MockUser
    {
        List<User> mockUserList = new()
        {
            new User { Id = 0, Name = "Bilbo", Age = 35, Address = "Middle-earth" },
            new User { Id = 1, Name = "Frodo", Age = 22, Address = "Mordor" },
            new User { Id = 2, Name = "Samwise", Age = 27, Address = "Shire" },
            new User { Id = 3, Name = "Peregrin", Age = 18, Address = "Shire" },
            new User { Id = 4, Name = "Legolas", Age = 115, Address = "Gondor" }
        };
    }
}
