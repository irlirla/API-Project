using FranchiseService.Commands.Interfaces;
using FranchiseService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranchiseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FranchiseController : ControllerBase
    {
        [HttpPost]
        public Task Post([FromServices] IAsyncPostCommand<Franchise> cmd, [FromBody] Franchise franchise) /*[FromServices] IRequsetClient<FranchiseRequest>*/
        {
            //try {req.GetResponse<FranchiseResponse>(new FranchiseRequest { FranchiseID = })
            return cmd.Execute(franchise);
        }

        [HttpGet("{id}")]
        public Task<FranchiseDTO> GetById([FromServices] IAsyncGetByIDCommand<FranchiseDTO> cmd, int id)
        {
            return cmd.Execute(id);
        }

        //[HttpGet("{id}")]
        //public Task<FranchiseResponse> GetById([FromServices] IRequestClient<FranchiseRequest> req, int id)
        //{
        //  return (await req.GetResponse<FranchiseResponse>(new FranchiseRequest() {FranchiseID = id})).Message;
        //}

        //[HttpGet]
        //public Task<FranchiseResponse> Get([FromServices] IRequestClient<FranchiseRequest> req, int id)
        //{
        //  return (await req.GetResponse<FranchiseResponse>(new FranchiseRequest())).Message;
        //}

        [HttpGet]
        public Task<IEnumerable<FranchiseDTO>> Get([FromServices] IAsyncGetAllCommand<FranchiseDTO> cmd)
        {
            return cmd.Execute();
        }

        [HttpDelete]
        public Task Delete([FromServices] IAsyncDeleteCommand<Franchise> cmd, int id)
        {
            return cmd.Execute(id);
        }

        [HttpPut]
        public Task Put([FromServices] IAsyncPutCommand<Franchise> cmd, [FromBody] Franchise franchise)
        {
            return cmd.Execute(franchise);
        }
    }
}
