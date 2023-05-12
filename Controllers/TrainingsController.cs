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
    public class TrainingsController : ControllerBase
    {
        private readonly TrainingDataContext _context;

        public TrainingsController(TrainingDataContext context)
        {
            _context = context;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetAllTrainings()
        {
          if (_context.Training == null)
          {
              return NotFound();
          }
            return await _context.Training.ToListAsync();
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTrainingById(int id)
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

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainingByName(string name)
        {
            if (_context.Training == null)
            {
                return NotFound();
            }
            var training = await _context.Training.Where(t => t.TrainingName.Contains(name)).ToListAsync();
           

            if (training == null)
            {
                return NotFound();
            }

            return training;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetTrainingByDate([FromQuery] DateDTO dateInterval)
        {
            if (_context.Training == null)
            {
                return NotFound();
            }
            var startDate = new DateTime(dateInterval.yearStart, dateInterval.monthStart, dateInterval.dayStart);
            var endDate = new DateTime(dateInterval.yearStart, dateInterval.monthStart, dateInterval.dayStart + 1);//+1
            var training = await _context.Training.Where(t => (t.TrainingDate <= endDate && t.TrainingDate >= startDate)).Select(t=> t.TrainingName).ToListAsync();

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

        [HttpPut("{id},{time}")]
        public async Task<IActionResult> IncreaseTrainingDuration(int id, int time)
        {
            var training = await _context.Training.FindAsync(id);

            if (id != training.TrainingId)
            {
                return BadRequest();
            }

            training.IncreaseTrainingDuration(time);

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
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeTrainingDate(int id, [FromQuery] DateDTO dateInterval)
        {
            var newDate = new DateTime(dateInterval.yearStart, dateInterval.monthStart, dateInterval.dayStart, dateInterval.hourStart, dateInterval.minuteStart, 0);
            var training = await _context.Training.FindAsync(id);
            if (id != training.TrainingId)
            {
                return BadRequest();
            }

            training.ChangeTrainingDate(newDate);

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
            var trainer = await _context.Trainer.FindAsync(training.TrainerId);
            trainer.AddTraining(training);
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

            var trainer = await _context.Trainer.FindAsync(training.TrainerId);
            trainer.DeleteTraining(training);

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
