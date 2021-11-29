using System;
using System.Collections.Generic;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context)
        {
            this.Context = context;
        }

        public override Section Get(int id)
        {
            return this.Context.Set<Section>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<Section> GetAll()
        {
            return this.Context.Set<Section>();
        }
        
        public bool Exists(string name)
        {
            var element = Context.Set<Section>().FirstOrDefaultAsync(x => x.Name == name);

            return Context.Set<Section>().FirstOrDefaultAsync(x => x.Name == name).Result != null;
        }
    }
}
