using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gribanova_API.Models;

namespace Gribanova_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly TrainingDataContext _context;

        public TrainingsController(TrainingDataContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTraining()
        {
          if (_context.Training == null)
          {
              return NotFound();
          }
            return await _context.Training.ToListAsync();
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
          if (_context.Training == null)
          {
              return NotFound();
          }
            var training = await _context.Training.FindAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        // PUT: api/Trainings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(int id, Training training)
        {
            if (id != training.TrainingId)
            {
                return BadRequest();
            }

            _context.Entry(training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // POST: api/Trainings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Training training)
        {
          if (_context.Training == null)
          {
              return Problem("Entity set 'TrainingDataContext.Training'  is null.");
          }
            _context.Training.Add(training);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraining", new { id = training.TrainingId }, training);
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            if (_context.Training == null)
            {
                return NotFound();
            }
            var training = await _context.Training.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            _context.Training.Remove(training);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingExists(int id)
        {
            return (_context.Training?.Any(e => e.TrainingId == id)).GetValueOrDefault();
        }
    }
}
