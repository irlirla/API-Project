using Services.Models;
using System.Collections.Generic;

namespace UnitTests.Mocks.BookService
{
    public class MockBook
    {
        List<Book> mockBookList = new()
        {
            new Book { ID = 111, Name = "Scott Pilgrim", Author = "Brayan Lee O'Malley" },
            new Book { ID = 222, Name = "IT", Author = "Steven King" },
            new Book { ID = 333, Name = "Big Little Lies", Author = "Liane Moriarty" }
        };

        Book mockBook = new() { ID = 111, Name = "Scott Pilgrim", Author = "Brayan Lee O'Malley" };
    }
}
