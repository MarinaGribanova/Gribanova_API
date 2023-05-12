using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gribanova_API.Models
{
    public class TrainerDTO
    {
        public int TrainerId { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerSpecialization { get; set; }

        public int TrainerwWorkExperience { get; set; }

        public string TrainerEmail { get; set; }

    }
}
