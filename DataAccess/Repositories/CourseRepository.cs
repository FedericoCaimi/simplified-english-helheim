using System;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(DbContext context)
        {
            this.Context = context;
        }

        public override Course Get(Guid id)
        {
            return this.Context.Set<Course>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<Course> GetAll()
        {
            return this.Context.Set<Course>();
        }
    }
}
