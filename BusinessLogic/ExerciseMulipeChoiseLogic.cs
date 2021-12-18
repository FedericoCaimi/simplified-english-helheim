using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Exceptions;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class ExerciseMultipeChoiseLogic : IExerciseMultipeChoiseLogic
    {
        private IExerciseMultipeChoiseRepository Repository;
        private ICourseLogic CourseLogic;
        private ISubSectionLogic SubSectionLogic;
        public ExerciseMultipeChoiseLogic(IExerciseMultipeChoiseRepository repository, ICourseLogic courseLogic, ISubSectionLogic subSectionLogic)
        {
            this.Repository = repository;
            this.CourseLogic = courseLogic;
            this.SubSectionLogic = subSectionLogic;
        }

        public ExerciseMultipeChoise Create(ExerciseMultipeChoise ExerciseMultipeChoise)
        {
            Course course = CourseLogic.Get(ExerciseMultipeChoise.Course.Id);
            SubSection subSection = SubSectionLogic.Get(ExerciseMultipeChoise.SubSection.Id);
            ExerciseMultipeChoise newExercise = new ExerciseMultipeChoise()
            {
                Course = course,
                SubSection = subSection,
                Title = ExerciseMultipeChoise.Title,
                Text = ExerciseMultipeChoise.Text,
                Questions = ExerciseMultipeChoise.Questions
            };
            Repository.Add(newExercise);
            Repository.Save();
            return newExercise;
        }

        public void Remove(int id)
        {
            ExerciseMultipeChoise exerciseFinded = Repository.Get(id);
            Repository.Remove(exerciseFinded);
            Repository.Save();
        }

        public ExerciseMultipeChoise Update(int id, ExerciseMultipeChoise ExerciseMultipeChoise)
        {
            if (id != ExerciseMultipeChoise.Id) throw new IncorrectParamException("Id and object id doesnt match");

            ExerciseMultipeChoise exerciseToUpdate = this.Repository.Get(id);

            exerciseToUpdate.Title = ExerciseMultipeChoise.Title;
            exerciseToUpdate.Text = ExerciseMultipeChoise.Text;
            exerciseToUpdate.Course = ExerciseMultipeChoise.Course;
            exerciseToUpdate.SubSection = ExerciseMultipeChoise.SubSection;
            exerciseToUpdate.Questions = ExerciseMultipeChoise.Questions;

            Repository.Update(exerciseToUpdate);
            Repository.Save();
            return exerciseToUpdate;
        }

        public ExerciseMultipeChoise Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<ExerciseMultipeChoise> GetAll() => Repository.GetAll();

    }
}
