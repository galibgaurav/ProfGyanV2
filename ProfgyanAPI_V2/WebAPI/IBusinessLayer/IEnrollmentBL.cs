using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IEnrollmentBL
    {
        Enrollment AddEnrollment(Enrollment enrollment);
        void DeleteEnrollment(string id);
        IEnumerable<Enrollment> GetEnrollment(Expression<Func<Enrollment, bool>> filter = null, Func<IQueryable<Enrollment>, IOrderedQueryable<Enrollment>> orderBy = null, string includeProperties = "");
        Enrollment GetEnrollment(string id);
        void UpdateEnrollment(Enrollment enrollment);
    }
}