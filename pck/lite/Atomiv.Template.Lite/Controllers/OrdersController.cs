using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Services.Interfaces;

namespace Atomiv.Template.Lite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            // return await _context.Orders.ToListAsync();
            // .Include(t => t.OrderItems).Include(o => o.OrderItems)
            // Orders.Include(t => t.OrderItems)
            var orders = await _service.GetOrders();
            return Ok(orders);
        }

        /* ??
        public Emplyee Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.EMplyees.FirstOrDefault(e => e.ID == id);
            }
        }
        */

        // GET: api/Orders/5
        // [HttpGet("{id:int}/medication")] - to only get teh medication, not disease as well
        // api/patients/3/medication .. see screenshot
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            // .FirstOrDEfaultAsync(i => i.PatientId == id);
            //_context.Orders.Include(t => t.OrderItems).FirstOrDefaultAsync(t => t.Id == id);
            var order = await _service.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        // , OrderItem orderItem
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            // var record = await _context.Orders.Include(t => t.OrderItems).FirstOrDefaultAsync(t => t.Id == id);

            // var orderToUpdate = await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(t => t.Id == order.Id);

            if (id != order.Id)
            {
                return BadRequest();
            }

            // db.Entry(Movie).State = EntityState.Modified;
            // db.Entry(Song).State = EntityState.Modified;
            //  _db.
            // order.OrderItems.Add(orderItem);
            // _context.Attach(order.OrderItems);
            // _context.Attach(orderToUpdate);
            // _context.Attach(order.OrderItems);
            // _context.Entry(order.OrderItems).State = EntityState.Modified;
            // db.Entry(personaldetails).State = EntityState.Modified;
            // ORIGINAL
            // _context.Entry(order).State = EntityState.Modified;
            // _context.Orders.Update(order);
            // await _context.SaveChangesAsync();
            // works but still list not updated
            // _context.Entry(orderToUpdate).CurrentValues.SetValues(order);
            // _context.Entry(order).State = EntityState.Modified;

            order = await _service.CreateOrder(order);

            if (order == null)
			{
                return NotFound();
			}

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            order = await _service.CreateOrder(order);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _service.DeleteOrder(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

    }
}
