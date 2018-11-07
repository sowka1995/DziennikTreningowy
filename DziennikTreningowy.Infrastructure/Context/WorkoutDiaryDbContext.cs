using DziennikTreningowy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DziennikTreningowy.Infrastructure.Context
{
    public class WorkoutDiaryDbContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public WorkoutDiaryDbContext() 
            : base()
        {

        }

        public WorkoutDiaryDbContext(DbContextOptions<WorkoutDiaryDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExercise>()
                .HasKey(ue => new { ue.UserId, ue.ExerciseId });

            modelBuilder.Entity<UserExercise>()
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserExercises)
                .HasForeignKey(ue => ue.UserId);

            modelBuilder.Entity<UserExercise>()
                .HasOne(ue => ue.Exercise)
                .WithMany(e => e.UserExercises)
                .HasForeignKey(ue => ue.ExerciseId);

            modelBuilder.Entity<WorkoutTemplateExercise>()
               .HasKey(wte => new { wte.WorkoutTemplateId, wte.ExerciseId });

            modelBuilder.Entity<WorkoutTemplateExercise>()
                .HasOne(wte => wte.WorkoutTemplate)
                .WithMany(u => u.WorkoutTemplateExercises)
                .HasForeignKey(wte => wte.WorkoutTemplateId);

            modelBuilder.Entity<WorkoutTemplateExercise>()
                .HasOne(wte => wte.Exercise)
                .WithMany(e => e.WorkoutTemplateExercises)
                .HasForeignKey(wte => wte.ExerciseId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}
