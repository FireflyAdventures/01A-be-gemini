using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FireFly_Dotnet.Entities;

namespace FireFly_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QapairsController : ControllerBase
    {
        private readonly FireFlyContext _context;

        public QapairsController(FireFlyContext context)
        {
            _context = context;
        }

        // GET: api/Qapairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qapair>>> GetQapairs()
        {
            return await _context.Qapairs.ToListAsync();
        }

        // GET: api/Qapairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qapair>> GetQapair(int id)
        {
            var qapair = await _context.Qapairs.FindAsync(id);

            if (qapair == null)
            {
                return NotFound();
            }

            return qapair;
        }

        // PUT: api/Qapairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQapair(int id, Qapair qapair)
        {
            if (id != qapair.Id)
            {
                return BadRequest();
            }

            _context.Entry(qapair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QapairExists(id))
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

        // POST: api/Qapairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qapair>> PostQapair(Qapair qapair)
        {
            _context.Qapairs.Add(qapair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQapair", new { id = qapair.Id }, qapair);
        }

        // DELETE: api/Qapairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQapair(int id)
        {
            var qapair = await _context.Qapairs.FindAsync(id);
            if (qapair == null)
            {
                return NotFound();
            }

            _context.Qapairs.Remove(qapair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QapairExists(int id)
        {
            return _context.Qapairs.Any(e => e.Id == id);
        }
    }
}
