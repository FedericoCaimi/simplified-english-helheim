using System.Collections.Generic;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SubSectionRepository : BaseRepository<SubSection>, ISubSectionRepository
    {
        public SubSectionRepository(DbContext context)
        {
            this.Context = context;
        }

        public override SubSection Get(int id)
        {
            return this.Context.Set<SubSection>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<SubSection> GetAll()
        {
            return this.Context.Set<SubSection>();
        }
        
        public bool Exists(string name)
        {
            var element = Context.Set<SubSection>().FirstOrDefaultAsync(x => x.Name == name);

            return Context.Set<SubSection>().FirstOrDefaultAsync(x => x.Name == name).Result != null;
        }
    }
}
