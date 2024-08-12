using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{

    public class GymContext : DbContext
    {

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Routine> Routines { get; set; }

        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Machines)
                .WithMany(m => m.Exercises)
                .HasForeignKey(e => e.MachineId);

            modelBuilder.Entity<RoutineExercise>()
                .HasKey(re => new { re.RoutineId, re.ExerciseId });

            modelBuilder.Entity<RoutineExercise>()
                .HasOne(re => re.Routine)
                .WithMany(r => r.RoutineExercises)
                .HasForeignKey(re => re.RoutineId);

            modelBuilder.Entity<RoutineExercise>()
                .HasOne(re => re.Exercise)
                .WithMany(e => e.RoutineExercises)
                .HasForeignKey(re => re.ExerciseId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
