using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessDataModel;
using IBusinessLayer;

namespace BusinessLayer
{
    public class CourseBL : ICourseBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Course GetCourse(int id)
        {
            return unitOfWork.CourseRepository.GetByID(id);
        }

        public Course AddCourse(Course course)
        {
            var result = unitOfWork.CourseRepository.Insert(course);
            unitOfWork.Save();
            return result;
        }

        public void UpdateCourse(Course course)
        {
            unitOfWork.CourseRepository.Update(course);
            unitOfWork.Save();
        }

        public void DeleteCourse(int id)
        {
            unitOfWork.CourseRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Course> GetCourse(Expression<Func<Course, bool>> filter = null,
            Func<IQueryable<Course>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.CourseRepository.Get(null, null, "");
            return result;
        }
    }
}

