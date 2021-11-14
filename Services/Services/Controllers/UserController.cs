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
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<UserDTO> Get([FromServices] IGetAllCommand<UserDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpGet("{id}")]
        public UserDTO GetById([FromServices] IGetByIDCommand<UserDTO> cmd, int id)
        {
            return cmd.Execute(id);
        }

        [HttpDelete("{id}")]
        public void Delete([FromServices] IDeleteCommand<User> cmd, int id)
        {
            cmd.Execute(id);
        }

        [HttpPost]
        public void Post([FromServices] IPostCommand<User> cmd, [FromBody] User user)
        {
            cmd.Execute(user);
        }

        [HttpPut]
        public void Put([FromServices] IPutCommand<User> cmd, [FromBody] User user)
        {
            cmd.Execute(user);
        }

    }
}
