using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ExerciseMultipeChoise>().ToTable("ExerciseMultipeChoise");
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SubSection> SubSection { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseMultipeChoise> ExerciseMultipeChoise { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public Context(DbContextOptions options) : base(options) { }
    }
}