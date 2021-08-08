using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImportExcelDataAPI.Models;

namespace ImportExcelDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportItemsController : ControllerBase
    {
        private readonly APIContext _context;

        public ImportItemsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/ImportItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportItem>>> GetImportItems()
        {
            return await _context.ImportItems.ToListAsync();
        }

        // GET: api/ImportItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ImportItem>> GetImportItem(int id)
        //{
        //    var importItem = await _context.ImportItems.FindAsync(id);

        //    if (importItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return importItem;
        //}

        // GET: api/ImportItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ImportItem>>> GetImportItemByImportID(int id)
        {
            //ImportItem[] importItem = 

            //if (importItem == null)
            //{
            //    return NotFound();
            //}

            return await _context.ImportItems.Where(i => i.ImportID == id).ToListAsync(); 
        }

        // PUT: api/ImportItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImportItem(int id, ImportItem importItem)
        {
            if (id != importItem.ImportItemID)
            {
                return BadRequest();
            }

            _context.Entry(importItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportItemExists(id))
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

        // POST: api/ImportItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImportItem>> PostImportItem(ImportItem importItem)
        {
            _context.ImportItems.Add(importItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImportItem", new { id = importItem.ImportItemID }, importItem);
        }

        // DELETE: api/ImportItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImportItem(int id)
        {
            var importItem = await _context.ImportItems.FindAsync(id);
            if (importItem == null)
            {
                return NotFound();
            }

            _context.ImportItems.Remove(importItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImportItemExists(int id)
        {
            return _context.ImportItems.Any(e => e.ImportItemID == id);
        }
    }
}
