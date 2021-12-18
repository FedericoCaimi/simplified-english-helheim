using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Exceptions;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class SubSectionLogic : ISubSectionLogic
    {
        private ISubSectionRepository Repository;
        private ISectionLogic SectionLogic;
        public SubSectionLogic(ISubSectionRepository repository, ISectionLogic sectionLogic)
        {
            this.Repository = repository;
            this.SectionLogic = sectionLogic;
        }

        public SubSection Create(SubSection subSection)
        {
            bool exists = Repository.Exists(subSection.Name);
            if(!exists){
                Section section = SectionLogic.Get(subSection.Section.Id);
                if(section != null){
                    SubSection newSubSection = new SubSection()
                    {
                        Name = subSection.Name,
                        Description = subSection.Description,
                        Section = section
                    };
                    Repository.Add(newSubSection);
                    Repository.Save();
                    return newSubSection;
                }else{
                    throw new SectionNotFoundException();
                }
            }
            else{
                throw new DBNamelreadyExistsException();
            }
        }

        public void Remove(int id)
        {
            SubSection subSectionFinded = Repository.Get(id);
            Repository.Remove(subSectionFinded);
            Repository.Save();
        }

        public SubSection Update(int id, SubSection subSection)
        {
            if (id != subSection.Id) throw new IncorrectParamException("Id and object id doesnt match");

            SubSection subSectionToUpdate = this.Repository.Get(id);

            subSectionToUpdate.Name = subSection.Name;
            subSectionToUpdate.Description = subSection.Description;
            subSectionToUpdate.Description = subSection.Description;

            Repository.Update(subSectionToUpdate);
            Repository.Save();
            return subSection;
        }

        public SubSection Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<SubSection> GetAll() => Repository.GetAll();

    }
}
