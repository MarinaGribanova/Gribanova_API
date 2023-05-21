namespace Gribanova_API.Models
{
    public class ClassesDTO
    {
        public class TrainingInfoDTO
        {
            public string TrainingName { get; set; }
            public DateTime TrainingDate { get; set; }
            public int TrainingDuration { get; set; }
            public int TrainingRoom { get; set; }
            public int Price { get; set; }
            public TrainerInfoDTO Trainer { get; set; }
        }
            
    }
    public class TrainerInfoDTO
    {
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }

    }

        public class DateDTOForSerach
        {
            public int yearStart { get; set; }
            public int monthStart { get; set; }
            public int dayStart { get; set; }
        }

}
