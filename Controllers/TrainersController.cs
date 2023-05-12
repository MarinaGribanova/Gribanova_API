using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gribanova_API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gribanova_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly TrainingDataContext _context;

        public TrainersController(TrainingDataContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetAllTrainers()
        {
          if (_context.Trainer == null)
          {
              return NotFound();
          }
            return await _context.Trainer.Include(t => t.TrainerTrainings).ToListAsync();
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainerById(int id)
        {
          if (_context.Trainer == null)
          {
              return NotFound();
          }
            var trainer = await _context.Trainer.FindAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainerBySpec(string name)
        {
            if (_context.Trainer == null)
            {
                return NotFound();
            }
      
            var trainer = await _context.Trainer.Where(t => t.TrainerSpecialization.Contains(name)).Include(t => t.TrainerTrainings).ToListAsync();
            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, Trainer trainer)
        {
            if (id != trainer.TrainerId)
            {
                return BadRequest();
            }

            _context.Entry(trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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



        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(TrainerDTO trainerdto)
        {
          if (_context.Trainer == null)
          {
              return Problem("Entity set 'TrainingDataContext.Trainer'  is null.");
          }
            Trainer trainer = (Trainer)trainerdto;
            _context.Trainer.Add(trainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainer", new { id = trainer.TrainerId }, trainer);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            if (_context.Trainer == null)
            {
                return NotFound();
            }
            var trainer = await _context.Trainer.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainer.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return (_context.Trainer?.Any(e => e.TrainerId == id)).GetValueOrDefault();
        }
    }
}
