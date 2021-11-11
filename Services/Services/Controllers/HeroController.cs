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
    public class HeroController : ControllerBase
    {
        [HttpPost]
        public Task Post([FromServices] IAsyncPostCommand<Hero> cmd, [FromBody] Hero hero)
        {
            return cmd.Execute(hero);
        }

        [HttpGet("{id}")]
        public Task<HeroDTO> GetById([FromServices] IAsyncGetByIDCommand<HeroDTO> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpGet]
        public Task<IEnumerable<HeroDTO>> Get([FromServices] IAsyncGetAllCommand<HeroDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpDelete]
        public Task Delete([FromServices] IAsyncDeleteCommand<Hero> cmd, [FromQuery] int id)
        {
            return cmd.Execute(id);
        }

        [HttpPut]
        public Task Put([FromServices] IAsyncPutCommand<Hero> cmd, [FromBody] Hero hero)
        {
            return cmd.Execute(hero);
        }
    }
}
