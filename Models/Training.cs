namespace Gribanova_API.Models
{
    public class Training
    {
         public int TrainingId { get; set; } 
        public string TrainingName { get; set; } 
        public DateTime TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
        public int TrainingDuration { get; set; }
        public ICollection<Trainer> TrainingTrainers { get; set; }
    }
}
