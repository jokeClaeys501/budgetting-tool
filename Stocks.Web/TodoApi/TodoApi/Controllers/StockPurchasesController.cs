using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPurchasesController : ControllerBase
    {
        private readonly StockPurchaseContext _context;

        public StockPurchasesController(StockPurchaseContext context)
        {
            _context = context;
        }

        // GET: api/StockPurchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockPurchase>>> GetStockPurchases()
        {
            return await _context.StockPurchases
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockPurchase>> GetStockPurchase(int id)
        {
            var stockPurchase = await _context.StockPurchases.FindAsync(id);

            if (stockPurchase == null)
            {
                return NotFound();
            }

            return stockPurchase;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, StockPurchase updatedStockPurchase)
        {
            if (id != updatedStockPurchase.Id)
            {
                return BadRequest();
            }

            var stockPurchaseFromDB = await _context.StockPurchases.FindAsync(id);
            if (stockPurchaseFromDB == null)
            {
                return NotFound();
            }

            stockPurchaseFromDB.Tracker = updatedStockPurchase.Tracker;
            stockPurchaseFromDB.Amount = updatedStockPurchase.Amount;
            stockPurchaseFromDB.Value = updatedStockPurchase.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StockPurchaseExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<StockPurchase>> CreateTodoItem(StockPurchase stockPurchase)
        {

            _context.StockPurchases.Add(stockPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStockPurchase),
                new { id = stockPurchase.Id },
                stockPurchase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var stockPurchasesToRemove = await _context.StockPurchases.FindAsync(id);

            if (stockPurchasesToRemove == null)
            {
                return NotFound();
            }

            _context.StockPurchases.Remove(stockPurchasesToRemove);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockPurchaseExists(long id) =>
             _context.StockPurchases.Any(e => e.Id == id);
    }
}
