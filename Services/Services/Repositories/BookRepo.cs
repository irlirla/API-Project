using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class BookRepo : IRepository<Book>
    {

        readonly string text1 = "Book.txt";

        public void Delete(int id)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(text1, false))
                {
                    sw.WriteLine("");
                }
            }
            catch
            {

            }
        }

        public IEnumerable<Book> Get()
        {
            List<Book> books = new();
            using StreamReader sr = new StreamReader(text1);
            while (sr.ReadLine() != null)
            {
                books.Add(new Book { });
            }
            return books;
        }

        public Book GetById(int id)
        {
            //if (File.Exists(text1))
            //{
            string name = File.ReadLines(text1)
            .SkipWhile(line => !line.Contains($"ID = {id}")) //берет эту строку с ид или нет?
            .Skip(id.ToString().Length)
            .TakeWhile(line => !line.Contains("Author = ")).ToString();

            string author = File.ReadLines(text1)
            .SkipWhile(line => !line.Contains($"Name = {name}"))
            .Skip(id.ToString().Length)
            .TakeWhile(line => !line.Contains("ID")).ToString();

            Book book = new Book { ID = id, Name = name, Author = author };
            return book;
            //}
            //else
            //{
            //    //return "There's no such book.";
            //}
        }

        public void Post(Book book)
        {
            if (File.Exists(text1))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("Book.txt", true))
                    {
                        sw.WriteLine($"ID = {book.ID}, Name = {book.Name}, Author = {book.Author}\n");
                    }
                }
                catch (Exception e)
                {
                    //return e.Message; не return  a что?
                }
            }

            //return "The book was written.";
        }

        public void Put(Book book)
        {
            if (File.Exists(text1))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(text1, false))
                    {
                        File.ReadLines(text1)
                       .SkipWhile(line => !line.Contains($"ID = {book.ID}"))
                       .Skip(book.ID.ToString().Length);
                        //.Write(book.Name);
                    }
                }
                catch (Exception e)
                {
                    //return e.Message;
                }
            }

            //return "The book was written.";
    }
    }
}
