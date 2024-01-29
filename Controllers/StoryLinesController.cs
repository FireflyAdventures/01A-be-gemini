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
    public class StoryLinesController : ControllerBase
    {
        private readonly FireFlyContext _context;

        public StoryLinesController(FireFlyContext context)
        {
            _context = context;
        }

        // GET: api/StoryLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryLine>>> GetStoryLines()
        {
            return await _context.StoryLines.ToListAsync();
        }

        // GET: api/StoryLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoryLine>> GetStoryLine(int id)
        {
            var storyLine = await _context.StoryLines.FindAsync(id);

            if (storyLine == null)
            {
                return NotFound();
            }

            return storyLine;
        }

        // PUT: api/StoryLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoryLine(int id, StoryLine storyLine)
        {
            if (id != storyLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(storyLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryLineExists(id))
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

        // POST: api/StoryLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoryLine>> PostStoryLine(StoryLine storyLine)
        {
            _context.StoryLines.Add(storyLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoryLine", new { id = storyLine.Id }, storyLine);
        }

        // DELETE: api/StoryLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoryLine(int id)
        {
            var storyLine = await _context.StoryLines.FindAsync(id);
            if (storyLine == null)
            {
                return NotFound();
            }

            _context.StoryLines.Remove(storyLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoryLineExists(int id)
        {
            return _context.StoryLines.Any(e => e.Id == id);
        }
    }
}
