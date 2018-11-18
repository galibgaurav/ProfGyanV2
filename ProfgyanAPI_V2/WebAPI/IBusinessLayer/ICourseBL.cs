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
        void DeleteCourse(string id);
        IEnumerable<Course> GetCourse(Expression<Func<Course, bool>> filter = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, string includeProperties = "");
        Course GetCourse(string id);
        void UpdateCourse(Course course);
    }
}