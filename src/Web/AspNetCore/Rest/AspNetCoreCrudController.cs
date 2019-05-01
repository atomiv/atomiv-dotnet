using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Optivem.Framework.Core.Common.Repository;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class AspNetCoreCrudController<TUnitOfWork, TService, TRequest, TResponse, TKey> 
        : ControllerBase
        where TUnitOfWork : IUnitOfWork
        where TService : ICrudService<TRequest, TResponse, TKey>
    {
        private readonly TUnitOfWork unitOfWork;
        private readonly TService service;
        private readonly Func<TRequest, TKey> requestIdGetter;
        private readonly Func<TResponse, TKey> responseIdGetter;

        public AspNetCoreCrudController(TUnitOfWork unitOfWork, TService service, Func<TRequest, TKey> requestIdGetter, Func<TResponse, TKey> responseIdGetter)
        {
            this.unitOfWork = unitOfWork;
            this.service = service;
            this.requestIdGetter = requestIdGetter;
            this.responseIdGetter = responseIdGetter;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TResponse>>> GetResources()
        {
            var result = await service.GetAsync();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TResponse>> GetResource(TKey id)
        {
            var supplier = await service.GetAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutResource(TKey id, TRequest request)
        {
            var requestId = requestIdGetter(request);
            
            if (id != null && !id.Equals(requestId))
            {
                return BadRequest();
            }

            try
            {
                service.Update(request);

                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TResponse>> PostResource(TRequest request)
        {
            var response = service.Add(request);

            await unitOfWork.SaveChangesAsync();

            var responseId = responseIdGetter(response);

            return CreatedAtAction("GetResource", new { id = responseId }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(TKey id)
        {
            var exists = service.Exists(id);

            if (!exists)
            {
                return NotFound();
            }

            service.Delete(id);

            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

    }
}
