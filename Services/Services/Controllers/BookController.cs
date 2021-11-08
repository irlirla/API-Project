using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.IO;
using System;
using Services.Repositories;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public void PostBook([FromBody] Book book)
        {
        }

        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {
        }
    }
}

