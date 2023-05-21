using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Gribanova_API.Models
{
        public class TrainingDataContext : DbContext
        {

            public TrainingDataContext(DbContextOptions<TrainingDataContext> options)
                : base(options)
            {
                Database.Migrate();
            }

            public DbSet<Gribanova_API.Models.Trainer> Trainer { get; set; } = default!;
            public DbSet<Gribanova_API.Models.Training> Training { get; set; } = default!;

        }
}
