using System;
using System.Collections.Generic;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context)
        {
            this.Context = context;
        }

        public override Course Get(int id)
        {
            return this.Context.Set<Course>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<Course> GetAll()
        {
            return this.Context.Set<Course>();
        }
        
        public bool Exists(string name)
        {
            var element = Context.Set<Course>().FirstOrDefaultAsync(x => x.Name == name);

            return Context.Set<Course>().FirstOrDefaultAsync(x => x.Name == name).Result != null;
        }
    }
}
