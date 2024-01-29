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
    public class UserStudentAnswersController : ControllerBase
    {
        private readonly FireFlyContext _context;

        public UserStudentAnswersController(FireFlyContext context)
        {
            _context = context;
        }

        // GET: api/UserStudentAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStudentAnswer>>> GetUserStudentAnswers()
        {
            return await _context.UserStudentAnswers.ToListAsync();
        }

        // GET: api/UserStudentAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStudentAnswer>> GetUserStudentAnswer(int id)
        {
            var userStudentAnswer = await _context.UserStudentAnswers.FindAsync(id);

            if (userStudentAnswer == null)
            {
                return NotFound();
            }

            return userStudentAnswer;
        }

        // PUT: api/UserStudentAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStudentAnswer(int id, UserStudentAnswer userStudentAnswer)
        {
            if (id != userStudentAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(userStudentAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStudentAnswerExists(id))
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

        // POST: api/UserStudentAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserStudentAnswer>> PostUserStudentAnswer(UserStudentAnswer userStudentAnswer)
        {
            _context.UserStudentAnswers.Add(userStudentAnswer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserStudentAnswerExists(userStudentAnswer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserStudentAnswer", new { id = userStudentAnswer.Id }, userStudentAnswer);
        }

        // DELETE: api/UserStudentAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStudentAnswer(int id)
        {
            var userStudentAnswer = await _context.UserStudentAnswers.FindAsync(id);
            if (userStudentAnswer == null)
            {
                return NotFound();
            }

            _context.UserStudentAnswers.Remove(userStudentAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStudentAnswerExists(int id)
        {
            return _context.UserStudentAnswers.Any(e => e.Id == id);
        }
    }
}
