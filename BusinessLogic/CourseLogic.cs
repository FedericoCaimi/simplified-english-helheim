using BusinessLogic.Interface;
using DataAccess.Interface;
using Domain;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class CourseLogic : ICourseLogic
    {
        //private IRepository<Course> Repository;
        private ICourseRepository Repository;
        public CourseLogic(ICourseRepository repository)
        {
            this.Repository = repository;
        }

        public Course Create(Course course)
        {
            bool exists = Repository.Exists(course.Name);
            if(!exists){
                Course newCourse = new Course()
                {
                    Name = course.Name,
                    Description = course.Description
                };
                Repository.Add(newCourse);
                Repository.Save();
                return newCourse;
            }
            else{
                throw new DBNamelreadyExistsException();
            }
        }

        public void Remove(int id)
        {
            Course courseFinded = Repository.Get(id);
            Repository.Remove(courseFinded);
            Repository.Save();
        }

        public Course Update(int id, Course course)
        {
            //if (id != course.Id) throw new IncorrectParamException("Id and object id doesnt match");

            Course courseToUpdate = this.Repository.Get(id);

            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;

            Repository.Update(courseToUpdate);
            Repository.Save();
            return course;
        }

        public Course Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<Course> GetAll() => Repository.GetAll();

    }
}
