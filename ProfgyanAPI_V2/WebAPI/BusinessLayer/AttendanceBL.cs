using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessDataModel;
using DataAccessLayer;
using IBusinessLayer;

namespace BusinessLayer
{
    public class AttendanceBL:IAttendanceBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Attendance GetAttendance(int id)
        {
            return unitOfWork.AttendanceRepository.GetByID(id);
        }

        public Attendance AddAttendance(Attendance attendance)
        {
            var result = unitOfWork.AttendanceRepository.Insert(attendance);
            unitOfWork.Save();
            return result;
        }

        public void UpdateAttendance(Attendance attendance)
        {
            unitOfWork.AttendanceRepository.Update(attendance);
            unitOfWork.Save();
        }

        public void DeleteAttendance(int id)
        {
            unitOfWork.AttendanceRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Attendance> GetAttendance(Expression<Func<Attendance, bool>> filter = null,
            Func<IQueryable<Attendance>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.AttendanceRepository.Get(null, null, "");
            return result;
        }


    }
}
