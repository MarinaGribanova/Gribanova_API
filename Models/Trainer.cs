﻿using System.Reflection;
using Gribanova_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Gribanova_API.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
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

        public static explicit operator Trainer(TrainerDTO trainerdto)
        {
            Trainer trainer = new Trainer();
            trainer.TrainerId = trainerdto.TrainerId;
            trainer.TrainerFirstName = trainerdto.TrainerFirstName;
            trainer.TrainerLastName = trainerdto.TrainerLastName;
            trainer.TrainerSpecialization = trainerdto.TrainerSpecialization;
            trainer.TrainerwWorkExperience = trainerdto.TrainerwWorkExperience;
            trainer.TrainerEmail = trainerdto.TrainerEmail;
            return trainer;
        }
    }
}


