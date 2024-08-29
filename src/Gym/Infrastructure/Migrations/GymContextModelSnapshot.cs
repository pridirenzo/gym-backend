﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciseId");

                    b.HasIndex("MachineId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Domain.Entities.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Domain.Entities.Routine", b =>
                {
                    b.Property<int>("RoutineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoutineId");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("Domain.Entities.RoutineExercise", b =>
                {
                    b.Property<int>("RoutineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoutineId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("RoutinesExercises");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.HasOne("Domain.Entities.Machine", "Machines")
                        .WithMany("Exercises")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Machines");
                });

            modelBuilder.Entity("Domain.Entities.RoutineExercise", b =>
                {
                    b.HasOne("Domain.Entities.Exercise", "Exercise")
                        .WithMany("RoutineExercise")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Routine", "Routine")
                        .WithMany("RoutineExercise")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Routine");
                });

            modelBuilder.Entity("Domain.Entities.Exercise", b =>
                {
                    b.Navigation("RoutineExercise");
                });

            modelBuilder.Entity("Domain.Entities.Machine", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("Domain.Entities.Routine", b =>
                {
                    b.Navigation("RoutineExercise");
                });
#pragma warning restore 612, 618
        }
    }
}
