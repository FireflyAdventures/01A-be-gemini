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
    public class StoryQuestionCategoriesController : ControllerBase
    {
        private readonly FireFlyContext _context;

        public StoryQuestionCategoriesController(FireFlyContext context)
        {
            _context = context;
        }

        // GET: api/StoryQuestionCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryQuestionCategory>>> GetStoryQuestionCategories()
        {
            return await _context.StoryQuestionCategories.ToListAsync();
        }

        // GET: api/StoryQuestionCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoryQuestionCategory>> GetStoryQuestionCategory(int id)
        {
            var storyQuestionCategory = await _context.StoryQuestionCategories.FindAsync(id);

            if (storyQuestionCategory == null)
            {
                return NotFound();
            }

            return storyQuestionCategory;
        }

        // PUT: api/StoryQuestionCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoryQuestionCategory(int id, StoryQuestionCategory storyQuestionCategory)
        {
            if (id != storyQuestionCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(storyQuestionCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryQuestionCategoryExists(id))
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

        // POST: api/StoryQuestionCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoryQuestionCategory>> PostStoryQuestionCategory(StoryQuestionCategory storyQuestionCategory)
        {
            _context.StoryQuestionCategories.Add(storyQuestionCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoryQuestionCategory", new { id = storyQuestionCategory.Id }, storyQuestionCategory);
        }

        // DELETE: api/StoryQuestionCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoryQuestionCategory(int id)
        {
            var storyQuestionCategory = await _context.StoryQuestionCategories.FindAsync(id);
            if (storyQuestionCategory == null)
            {
                return NotFound();
            }

            _context.StoryQuestionCategories.Remove(storyQuestionCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoryQuestionCategoryExists(int id)
        {
            return _context.StoryQuestionCategories.Any(e => e.Id == id);
        }
    }
}
