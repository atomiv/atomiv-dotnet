using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Framework.Web.AspNetCore
{
    public class AspNetCoreCrudController<TService, TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        : ControllerBase
        where TService : ICrudApplicationService<TKey, TFindAllRequest, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TUpdateRequest : IRequest<TKey>
        where TCreateResponse : IResponse<TKey>
    {
        public AspNetCoreCrudController(TService service)
        {
            this.Service = service;
        }

        protected TService Service { get; private set; }

        [HttpGet]
        public async Task<ActionResult<TFindAllResponse>> GetResources(TFindAllRequest request)
        {
            var response = await Service.FindAllAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TFindResponse>> GetResource(TKey id)
        {
            var response = await Service.FindAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<TCreateResponse>> PostResource(TCreateRequest request)
        {
            var response = await Service.CreateAsync(request);
            var responseId = response.Id;
            return CreatedAtAction("GetResource", new { id = responseId }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TUpdateResponse>> PutResource(TKey id, TUpdateRequest request)
        {
            var requestId = request.Id;

            var validId = id != null && requestId != null && id.Equals(requestId);

            if (!validId)
            {
                return BadRequest();
            }

            var response = await Service.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(TKey id)
        {
            await Service.DeleteAsync(id);
            return NoContent();
        }
    }
}