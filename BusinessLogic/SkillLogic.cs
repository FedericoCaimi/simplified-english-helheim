using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Exceptions;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class SectionLogic : ISectionLogic
    {
        private ISectionRepository Repository;
        public SectionLogic(ISectionRepository repository)
        {
            this.Repository = repository;
        }

        public Section Create(Section section)
        {
            bool exists = Repository.Exists(section.Name);
            if(!exists){
                Section newSection = new Section()
                {
                    Name = section.Name,
                    Description = section.Description
                };
                Repository.Add(newSection);
                Repository.Save();
                return newSection;
            }
            else{
                throw new DBNamelreadyExistsException();
            }
        }

        public void Remove(int id)
        {
            Section sectionFinded = Repository.Get(id);
            Repository.Remove(sectionFinded);
            Repository.Save();
        }

        public Section Update(int id, Section section)
        {
            if (id != section.Id) throw new IncorrectParamException("Id and object id doesnt match");

            Section sectionToUpdate = this.Repository.Get(id);

            sectionToUpdate.Name = section.Name;
            sectionToUpdate.Description = section.Description;

            Repository.Update(sectionToUpdate);
            Repository.Save();
            return section;
        }

        public Section Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<Section> GetAll() => Repository.GetAll();

    }
}
