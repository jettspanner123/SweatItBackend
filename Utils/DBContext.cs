using Microsoft.EntityFrameworkCore;
using SweatitBackEnd.Models.User;
using SweatItBackEnd.Models.Workout;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options) {
    public DbSet<BaseUser> Users => Set<BaseUser>();
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExerciseSet>()
            .HasOne(es => es.Workout)
            .WithMany(w => w.Sets)
            .HasForeignKey(es => es.WorkoutId);

        modelBuilder.Entity<Workout>()
            .ToTable("Workout")
            .HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}