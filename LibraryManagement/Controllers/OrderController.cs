using LibraryManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetOrderMasters()
        {
            return await _context.OrderMaster
                .ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMaster>> GetOrderMaster(long id)
        {
            //get fooditem from order details
            var orderDetails = await (from master in _context.Set<OrderMaster>()
                                      join detail in _context.Set<OrderDetail>()
                                      on master.OrderMasterId equals detail.OrderMasterId
                                      join book in _context.Set<Books>()
                                      on detail.BookItemId equals book.BookItemId
                                      where master.OrderMasterId == id

                                      select new
                                      {
                                          master.OrderMasterId,
                                          detail.OrderDetailId,
                                          detail.BookItemId,
                                          detail.Quantity,
                                          detail.BookItemPrice,
                                          book.BookItemName
                                      }).ToListAsync();

            // get order master
            var orderMaster = await (from a in _context.Set<OrderMaster>()
                                     where a.OrderMasterId == id

                                     select new
                                     {
                                         a.OrderMasterId,
                                         a.OrderNumber,
                                         a.StudentId,
                                         a.BMethod,
                                         a.Purpose,
                                         deletedOrderItemIds = "",
                                         orderDetails = orderDetails
                                     }).FirstOrDefaultAsync();

            if (orderMaster == null)
            {
                return NotFound();
            }

            return Ok(orderMaster);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMaster(long id, OrderMaster orderMaster)
        {
            if (id != orderMaster.OrderMasterId)
            {
                return BadRequest();
            }

            _context.Entry(orderMaster).State = EntityState.Modified;

            //existing food items & newly added food items
            foreach (OrderDetail item in orderMaster.OrderDetails)
            {
                if (item.OrderDetailId == 0)
                    _context.OrderDetail.Add(item);
                else
                    _context.Entry(item).State = EntityState.Modified;
            }

            //deleted food items
            foreach (var i in orderMaster.DeletedOrderItemIds.Split(',').Where(x => x != ""))
            {
                OrderDetail y = _context.OrderDetail.Find(Convert.ToInt64(i));
                _context.OrderDetail.Remove(y);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMasterExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderMaster>> PostOrderMaster(OrderMaster orderMaster)
        {
            _context.OrderMaster.Add(orderMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMaster", new { id = orderMaster.OrderMasterId }, orderMaster);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMaster(long id)
        {
            var orderMaster = await _context.OrderMaster.FindAsync(id);
            if (orderMaster == null)
            {
                return NotFound();
            }

            _context.OrderMaster.Remove(orderMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderMasterExists(long id)
        {
            return _context.OrderMaster.Any(e => e.OrderMasterId == id);
        }
    }
}
