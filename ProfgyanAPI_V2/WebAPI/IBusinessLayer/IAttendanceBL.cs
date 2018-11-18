using BusinessDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IBusinessLayer
{
    public interface IAttendanceBL
    {
        Attendance AddAttendance(Attendance attendance);
        void DeleteAttendance(string id);
        IEnumerable<Attendance> GetAttendance(Expression<Func<Attendance, bool>> filter = null, Func<IQueryable<Attendance>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Attendance GetAttendance(string id);
        void UpdateAttendance(Attendance appointment);
    }
}