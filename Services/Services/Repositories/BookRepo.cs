using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.Repositories
{
    public class BookRepo : IRepository<Book>
    {
        const string str1 = "Success!";
        const string str2 = "There's no such file!";
        const string text1 = "Book.txt";
        private readonly BookValidator _validator;

        public BookRepo(BookValidator validator)
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
            try
            {
                using StreamReader sr = new StreamReader(text1);
                while (sr.ReadLine() != null)
                {
                    books.Add(new Book { });
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
            if (File.Exists(text1))
            {
                try
                {
                    string name = File.ReadLines(text1)
                    .SkipWhile(line => !line.Contains($"ID = {id}")) //берет эту строку с ид или нет?
                    .Skip(id.ToString().Length)
                    .TakeWhile(line => !line.Contains("Author = ")).ToString();

                    string author = File.ReadLines(text1)
                    .SkipWhile(line => !line.Contains($"Name = {name}"))
                    .Skip(id.ToString().Length)
                    .TakeWhile(line => !line.Contains("ID")).ToString();

                    Book book1 = new Book { ID = id, Name = name, Author = author };
                    return (book1, str1);
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
            if (File.Exists(text1) && _validator.Validate(book).IsValid is true)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("Book.txt", true))
                    {
                        sw.WriteLine($"ID = {book.ID}, Name = {book.Name}, Author = {book.Author}\n");
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
            if (File.Exists(text1) && _validator.Validate(book).IsValid is true)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(text1, false))
                    {
                        File.ReadLines(text1)
                       .SkipWhile(line => !line.Contains($"ID = {book.ID}"))
                       .Skip(book.ID.ToString().Length);
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
