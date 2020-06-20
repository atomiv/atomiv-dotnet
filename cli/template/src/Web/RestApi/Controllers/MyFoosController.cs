using Microsoft.AspNetCore.Mvc;
using Atomiv.Web.AspNetCore;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Application.MyFoos.Services;
using System.Threading.Tasks;

namespace Cli.Web.RestApi.Controllers
{
    [Route("api/my-foos")]
    [ApiController]
    public class MyFoosController : BaseController<IMyFooService>
    {
        public MyFoosController(IMyFooService service)
            : base(service)
        {
        }

        [HttpGet(Name ="list-my-foos")]
        [ProducesResponseType(typeof(ListMyFoosResponse), 200)]
        public async Task<ActionResult<ListMyFoosResponse>> ListMyFoosAsync()
        {
            var request = new ListMyFoosRequest();
            var response = await Service.ListMyFoosAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "find-my-foo")]
        [ProducesResponseType(typeof(FindMyFooResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindMyFooResponse>> FindMyFooAsync(int id)
        {
            var request = new FindMyFooRequest { Id = id };
            var response = await Service.FindMyFooAsync(request);
            return Ok(response);
        }

        [HttpPost(Name = "create-my-foo")]
        [ProducesResponseType(typeof(CreateMyFooResponse), 201)]
        public async Task<ActionResult<CreateMyFooResponse>> CreateMyFooAsync(CreateMyFooRequest request)
        {
            var response = await Service.CreateMyFooAsync(request);
            return CreatedAtRoute("find-my-foo", new { id = response.Id }, response);
        }

        [HttpPut("{id}", Name = "update-my-foo")]
        [ProducesResponseType(typeof(UpdateMyFooResponse), 201)]
        public async Task<ActionResult<UpdateMyFooResponse>> UpdateMyFooAsync(int id, UpdateMyFooRequest request)
        {
            var response = await Service.UpdateMyFooAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-my-foo")]
        public async Task<ActionResult> DeleteMyFooAsync(int id)
        {
            var request = new DeleteMyFooRequest { Id = id };
            var response = await Service.DeleteMyFooAsync(request);
            return NoContent();
        }
    }
}