using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ExerciseMulipeChoise>().ToTable("ExerciseMulipeChoise");
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseMulipeChoise> ExerciseMulipeChoise { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }

        public Context(DbContextOptions options) : base(options) { }
    }
}