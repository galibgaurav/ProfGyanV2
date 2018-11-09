using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IEnrollmentBL
    {
        Enrollment AddEnrollment(Enrollment enrollment);
        void DeleteEnrollment(int id);
        IEnumerable<Enrollment> GetEnrollment(Expression<Func<Enrollment, bool>> filter = null, Func<IQueryable<Enrollment>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Enrollment GetEnrollment(int id);
        void UpdateEnrollment(Enrollment enrollment);
    }
}