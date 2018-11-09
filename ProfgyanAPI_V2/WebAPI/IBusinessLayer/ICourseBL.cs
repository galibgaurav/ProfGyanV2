using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ICourseBL
    {
        Course AddCourse(Course course);
        void DeleteCourse(int id);
        IEnumerable<Course> GetCourse(Expression<Func<Course, bool>> filter = null, Func<IQueryable<Course>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Course GetCourse(int id);
        void UpdateCourse(Course course);
    }
}