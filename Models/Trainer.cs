using System.Reflection;

namespace Gribanova_API.Models
{
    public class Trainer
    {
        public int  TrainerId { get; set; } 
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }
        public string TrainerSpecialization { get; set; } 

        public int TrainerwWorkExperience { get; set; }

        public string TrainerEmail { get; set; }
        public ICollection<Training> TrainerTrainings { get; set; }

        public Trainer()
        {
            TrainerTrainings = new List<Training>();
        }
        public void AddTraining(Training training)
        {
            TrainerTrainings.Add(training);
        }

        public void DeleteTraining(Training training)
        {
            TrainerTrainings.Remove(training);
        }
    }
}
