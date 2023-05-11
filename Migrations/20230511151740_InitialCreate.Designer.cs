﻿// <auto-generated />
using System;
using Gribanova_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gribanova_API.Migrations
{
    [DbContext(typeof(TrainingDataContext))]
    [Migration("20230511151740_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gribanova_API.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerId"));

                    b.Property<string>("TrainerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainerwWorkExperience")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("Gribanova_API.Models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingId"));

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrainingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingDuration")
                        .HasColumnType("int");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingRoom")
                        .HasColumnType("int");

                    b.HasKey("TrainingId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("Gribanova_API.Models.Training", b =>
                {
                    b.HasOne("Gribanova_API.Models.Trainer", null)
                        .WithMany("TrainerTrainings")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gribanova_API.Models.Trainer", b =>
                {
                    b.Navigation("TrainerTrainings");
                });
#pragma warning restore 612, 618
        }
    }
}
