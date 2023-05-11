namespace Gribanova_API.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public DateTime TrainingDate { get; set; }
        public string TrainingDescription { get; set; }
        public int TrainingDuration { get; set; }
        public int TrainingRoom { get; set; }
        public int TrainerId { get; set; }

        public void IncreaseTrainingDuration(int minutes)
        {
            TrainingDuration += minutes;

        }
        public void ChangeTrainingDate(DateTime newDate)
        {
            TrainingDate = newDate;
        }

        public void ChangeTrainer(int NewTrainerId)
        {
            TrainerId = NewTrainerId;
        }
    }
}
