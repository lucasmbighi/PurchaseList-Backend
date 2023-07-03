using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseListApi.Models;

namespace PurchaseListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseListsController : ControllerBase
    {
        private readonly PurchaseListContext _context;

        public PurchaseListsController(PurchaseListContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseList>>> GetPurchaseLists()
        {
            if (_context.PurchaseLists == null)
            {
                return NotFound();
            }
            return await _context.PurchaseLists.ToListAsync();
        }

        // GET: api/PurchaseLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseList>> GetPurchaseList(long id)
        {
          if (_context.PurchaseLists == null)
          {
              return NotFound();
          }
            var purchaseList = await _context.PurchaseLists.FindAsync(id);

            if (purchaseList == null)
            {
                return NotFound();
            }

            return purchaseList;
        }

        // PUT: api/PurchaseLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseList(long id, PurchaseList purchaseList)
        {
            if (id != purchaseList.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseListExists(id))
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

        // POST: api/PurchaseLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PurchaseList>> PostPurchaseList(PurchaseList purchaseList)
        {
            _context.PurchaseLists.Add(purchaseList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseList), new { id = purchaseList.Id }, purchaseList);
        }

        // DELETE: api/PurchaseLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseList(long id)
        {
            if (_context.PurchaseLists == null)
            {
                return NotFound();
            }
            var purchaseList = await _context.PurchaseLists.FindAsync(id);
            if (purchaseList == null)
            {
                return NotFound();
            }

            _context.PurchaseLists.Remove(purchaseList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseListExists(long id)
        {
            return (_context.PurchaseLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
