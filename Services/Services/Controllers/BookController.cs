using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.IO;
using System;
using Services.Repositories;
using Services.Commands.Interfaces;
using System.Collections.Generic;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public void PostBook([FromServices] IPostCommand<Book> cmd, [FromBody] Book book)
        {
            cmd.Execute(book);
        }

        [HttpGet("{id}")]
        public BookDTO GetBookById([FromServices] IGetByIDCommand<BookDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpGet]
        public IEnumerable<BookDTO> Get([FromServices] IGetAllCommand<BookDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCommand<Book> cmd, [FromQuery] int id)
        {
            cmd.Execute(id);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<Book> cmd, [FromBody] Book book)
        {
            cmd.Execute(book);
        }
    }
}

