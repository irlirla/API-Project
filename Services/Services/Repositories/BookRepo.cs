using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Services.Repositories
{
    public class BookRepo : IRepository<Book>
    {
        public const string str1 = "Success!";
        public const string str2 = "There's no such file!";
        const string text1 = "Book.txt";
        private readonly IBookValidator _validator;

        public BookRepo(IBookValidator validator)
        {
            _validator = validator;
        }

        public string Delete(int id)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(text1, false))
                {
                    sw.WriteLine("");
                }
                return str1;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public (IEnumerable<Book>, string) Get()
        {
            List<Book> books = new();
            string[] line = new string[3];
            try
            {
                using StreamReader sr = new StreamReader(text1);
                while (sr.Peek() > -1)
                {
                    line = sr.ReadLine().Split("; ");
                    books.Add(new Book 
                    { 
                        ID = int.Parse(line[0]),
                        Name = line[1],
                        Author = line[2]
                    });
                }
                return (books, str1);
            }
            catch (Exception e)
            {
                return (books, e.Message);
            }
        }

        public (Book, string) GetById(int id)
        {
            Book book = new();
            string[] line = new string[3];
            if (File.Exists(text1))
            {
                try
                {
                    using StreamReader sr = new StreamReader(text1);
                    while (sr.Peek() > -1)
                    {
                        line = sr.ReadLine().Split(";");
                        if (int.Parse(line[0]) == id)
                        {
                            book.ID = int.Parse(line[0]);
                            book.Name = line[1];
                            book.Author = line[2];
                        }
                    }
                    return (book, str1);
                }
                catch (Exception e)
                {
                    return (book, e.Message);
                }
            }
            else
            {
                return (book, str2);
            }
        }

        public string Post(Book book)
        {
            if (File.Exists(text1) && _validator.Validate(book).IsValid)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(text1, true))
                    {
                        sw.WriteLine($"{book.ID}; {book.Name}; {book.Author}");
                    }
                    return str1;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return str2;
            }
        }

        public string Put(Book book)
        {
            if (File.Exists(text1) && _validator.Validate(book).IsValid)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(text1, false))
                    {
                        sw.WriteLine($"{book.ID}; {book.Name}; {book.Author}");
                        return "";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return str2;
            }
    }
    }
}
