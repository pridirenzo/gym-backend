using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GymContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutinesExercises { get; set; }

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
                .WithMany(r => r.RoutineExercise)
                .HasForeignKey(re => re.RoutineId);

            modelBuilder.Entity<RoutineExercise>()
                .HasOne(re => re.Exercise)
                .WithMany(e => e.RoutineExercise)
                .HasForeignKey(re => re.ExerciseId);


            base.OnModelCreating(modelBuilder);

            //Disable all default relationship cascade delete behavior
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
