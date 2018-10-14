using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private ModelDesignContainer context = new ModelDesignContainer();
        private Repository<Appointment> appointmentRepository;
        private Repository<ContactUs> contactUsRepository;

        public Repository<Appointment> AppointmentRepository
        {
            get
            {

                if (this.appointmentRepository == null)
                {
                    this.appointmentRepository = new Repository<Appointment>(context);
                }
                return appointmentRepository;
            }
        }
        public Repository<ContactUs> ContactUsRepository
        {
            get
            {

                if (this.contactUsRepository == null)
                {
                    this.contactUsRepository = new Repository<ContactUs>(context);
                }
                return contactUsRepository;
            }
        }




        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
