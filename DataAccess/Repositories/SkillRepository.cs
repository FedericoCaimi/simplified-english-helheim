using System.Collections.Generic;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DbContext context)
        {
            this.Context = context;
        }

        public override Skill Get(int id)
        {
            return this.Context.Set<Skill>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<Skill> GetAll()
        {
            return this.Context.Set<Skill>();
        }
        
        public bool Exists(string name)
        {
            var element = Context.Set<Skill>().FirstOrDefaultAsync(x => x.Name == name);

            return Context.Set<Skill>().FirstOrDefaultAsync(x => x.Name == name).Result != null;
        }
    }
}
