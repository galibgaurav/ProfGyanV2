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
    public class EnrollmentBL : IEnrollmentBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Enrollment GetEnrollment(string id)
        {
            return unitOfWork.EnrollmentRepository.GetByID(id);
        }

        public Enrollment AddEnrollment(Enrollment enrollment)
        {
            var result = unitOfWork.EnrollmentRepository.Insert(enrollment);
            unitOfWork.Save();
            return result;
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            unitOfWork.EnrollmentRepository.Update(enrollment);
            unitOfWork.Save();
        }

        public void DeleteEnrollment(string id)
        {
            unitOfWork.EnrollmentRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Enrollment> GetEnrollment(Expression<Func<Enrollment, bool>> filter = null,
            Func<IQueryable<Enrollment>, IOrderedQueryable<Enrollment>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.EnrollmentRepository.Get(null, null, "");
            return result;
        }
    }
}
