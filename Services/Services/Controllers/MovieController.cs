using Microsoft.AspNetCore.Mvc;
using Services.Commands.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieCoontroller : ControllerBase
    {
        [HttpPost]
        public Task Post([FromServices] IAsyncPostCommand<Movie> cmd, [FromBody] Movie movie)
        {
            return cmd.Execute(movie);
        }

        [HttpGet("{id}")]
        public Task<MovieDTO> GetById([FromServices] IAsyncGetByIDCommand<MovieDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpGet]
        public Task<IEnumerable<MovieDTO>> Get([FromServices] IAsyncGetAllCommand<MovieDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpDelete]
        public Task Delete([FromServices] IAsyncDeleteCommand<Movie> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPut]
        public Task Put([FromServices] IAsyncPutCommand<Movie> cmd, [FromBody] Movie movie)
        {
            return cmd.Execute(movie);
        }
    }
}
