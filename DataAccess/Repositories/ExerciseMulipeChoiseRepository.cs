using System.Collections.Generic;
using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ExerciseMultipeChoiseRepository : BaseRepository<ExerciseMultipeChoise>, IExerciseMultipeChoiseRepository
    {
        public ExerciseMultipeChoiseRepository(DbContext context)
        {
            this.Context = context;
        }

        public override ExerciseMultipeChoise Get(int id)
        {
            return this.Context.Set<ExerciseMultipeChoise>().FirstOrDefaultAsync(p => p.Id == id).Result;
        }

        public override IEnumerable<ExerciseMultipeChoise> GetAll()
        {
            return this.Context.Set<ExerciseMultipeChoise>().Include(x => x.Course).Include(x => x.SubSection).ThenInclude(x => x.Section).Include(x => x.Questions).ThenInclude(x => x.Option);
        }
    }
}
