using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Exceptions;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class SkillLogic : ISkillLogic
    {
        private ISkillRepository Repository;
        public SkillLogic(ISkillRepository repository)
        {
            this.Repository = repository;
        }

        public Skill Create(Skill skill)
        {
            bool exists = Repository.Exists(skill.Name);
            if(!exists){
                Skill newSkill = new Skill()
                {
                    Name = skill.Name,
                    Description = skill.Description
                };
                Repository.Add(newSkill);
                Repository.Save();
                return newSkill;
            }
            else{
                throw new DBNamelreadyExistsException();
            }
        }

        public void Remove(int id)
        {
            Skill skillFinded = Repository.Get(id);
            Repository.Remove(skillFinded);
            Repository.Save();
        }

        public Skill Update(int id, Skill skill)
        {
            if (id != skill.Id) throw new IncorrectParamException("Id and object id doesnt match");

            Skill skillToUpdate = this.Repository.Get(id);

            skillToUpdate.Name = skill.Name;
            skillToUpdate.Description = skill.Description;

            Repository.Update(skillToUpdate);
            Repository.Save();
            return skill;
        }

        public Skill Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<Skill> GetAll() => Repository.GetAll();

    }
}
