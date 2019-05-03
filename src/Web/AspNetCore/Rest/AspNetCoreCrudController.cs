using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application.Ports.In.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Optivem.Framework.Core.Application.Ports.In.Dtos;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class AspNetCoreCrudController<TService, TKey, TFindAllRequest, TFindRequest, TCreateRequest, TUpdateRequest, TDeleteRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse> 
        : ControllerBase
        where TService : ICrudService<TKey, TCreateRequest, TUpdateRequest, TFindAllResponse, TFindResponse, TCreateResponse, TUpdateResponse>
        where TUpdateRequest : IIdentifiable<TKey>
        where TCreateResponse : IIdentifiable<TKey>
    {
        public AspNetCoreCrudController(TService service)
        {
            this.Service = service;
        }

        protected TService Service { get; private set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TFindAllResponse>>> GetResources()
        {
            var responses = await Service.FindAllAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TFindResponse>> GetResource(TKey id)
        {
            var supplier = await Service.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
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

            if(response == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(TKey id)
        {
            var deleted = await Service.DeleteAsync(id);

            if(!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
