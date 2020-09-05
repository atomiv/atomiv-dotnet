using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;

namespace Atomiv.Template.Lite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public OrdersController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            // return await _context.Orders.ToListAsync();
            // .Include(t => t.OrderItems).Include(o => o.OrderItems)
            return await _context.Orders.Include(t => t.OrderItems).ToListAsync();
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
            var order = await _context.Orders.Include(t => t.OrderItems).FirstOrDefaultAsync(t => t.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
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
            _context.Entry(order).State = EntityState.Modified;
            // _context.Orders.Update(order);
            // await _context.SaveChangesAsync();
            // works but still list not updated
            // _context.Entry(orderToUpdate).CurrentValues.SetValues(order);
            // _context.Entry(order).State = EntityState.Modified;

            try
            {
                // await _context.SaveChangesAsync();
 // var order = await _context.Orders.Include(t => t.OrderItems).SingleOrDefaultAsync(t => t.Id == id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetOrder", new { id = order.Id }, order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        /* ??
        public void Post([FromBody] Employee employee)
        {
            using(EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Add(employee);
                entities.SaveCahnegs();
            }
        }
        */

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
