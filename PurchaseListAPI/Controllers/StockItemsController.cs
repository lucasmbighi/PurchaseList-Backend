using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseListApi.Models;
using PurchaseListAPI.Models;

namespace PurchaseListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemsController : ControllerBase
    {
        private readonly StockContext _context;

        public StockItemsController(StockContext context)
        {
            _context = context;
        }

        // GET: api/StockItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> GetStockItems()
        {
          if (_context.StockItems == null)
          {
              return NotFound();
          }
            return await _context.StockItems.ToListAsync();
        }

        // GET: api/StockItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockItem>> GetStockItem(long id)
        {
          if (_context.StockItems == null)
          {
              return NotFound();
          }
            var stockItem = await _context.StockItems.FindAsync(id);

            if (stockItem == null)
            {
                return NotFound();
            }

            return stockItem;
        }

        // PUT: api/StockItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItem(long id, StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
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

        // POST: api/StockItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockItem>> PostStockItem(StockItem stockItem)
        {
            _context.StockItems.Add(stockItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStockItem), new { id = stockItem.Id }, stockItem);
        }

        // DELETE: api/StockItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockItem(long id)
        {
            if (_context.StockItems == null)
            {
                return NotFound();
            }
            var stockItem = await _context.StockItems.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            _context.StockItems.Remove(stockItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockItemExists(long id)
        {
            return (_context.StockItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
