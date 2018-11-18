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
    public class AppointmentBL : IAppointmentBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Appointment GetAppointment(string id)
        {
            return unitOfWork.AppointmentRepository.GetByID(id);
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            var result = unitOfWork.AppointmentRepository.Insert(appointment);
            unitOfWork.Save();
            return result;
        }

        public void UpdateAppointment(Appointment appointment)
        {
            unitOfWork.AppointmentRepository.Update(appointment);
            unitOfWork.Save();
        }

        public void DeleteAppointment(string id)
        {
            unitOfWork.AppointmentRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Appointment> GetAppointment(Expression<Func<Appointment, bool>> filter = null,
            Func<IQueryable<Appointment>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.AppointmentRepository.Get(null, null, "");
            return result;
        }
    }
}
