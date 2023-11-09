using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FelrapportsApi.Data;
using FelrapportsApi.Model;

namespace FelrapportsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FelrapportsController : ControllerBase
    {
        private readonly FelrapportsApiContext _context;

        public FelrapportsController(FelrapportsApiContext context)
        {
            _context = context;
        }

        // GET: api/Felrapports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Felrapport>>> GetFelrapport()
        {
          if (_context.Felrapport == null)
          {
              return NotFound();
          }
            return await _context.Felrapport.ToListAsync();
        }

        // GET: api/Felrapports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Felrapport>> GetFelrapport(int id)
        {
          if (_context.Felrapport == null)
          {
              return NotFound();
          }
            var felrapport = await _context.Felrapport.FindAsync(id);

            if (felrapport == null)
            {
                return NotFound();
            }

            return felrapport;
        }

        // PUT: api/Felrapports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFelrapport(int id, Felrapport felrapport)
        {
            if (id != felrapport.Id)
            {
                return BadRequest();
            }

            _context.Entry(felrapport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FelrapportExists(id))
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

        // POST: api/Felrapports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Felrapport>> PostFelrapport(Felrapport felrapport)
        {
          if (_context.Felrapport == null)
          {
              return Problem("Entity set 'FelrapportsApiContext.Felrapport'  is null.");
          }
            _context.Felrapport.Add(felrapport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFelrapport", new { id = felrapport.Id }, felrapport);
        }

        // DELETE: api/Felrapports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFelrapport(int id)
        {
            if (_context.Felrapport == null)
            {
                return NotFound();
            }
            var felrapport = await _context.Felrapport.FindAsync(id);
            if (felrapport == null)
            {
                return NotFound();
            }

            _context.Felrapport.Remove(felrapport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FelrapportExists(int id)
        {
            return (_context.Felrapport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
