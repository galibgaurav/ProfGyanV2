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
    public class ContactUsBL : IContactUsBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ContactUs GetContactUs(int id)
        {
            return unitOfWork.ContactUsRepository.GetByID(id);
        }

        public ContactUs AddContactUs(ContactUs contactUs)
        {
            var result= unitOfWork.ContactUsRepository.Insert(contactUs);
            unitOfWork.Save();
            return result;
        }

        public void UpdateContactUs(ContactUs contactUs)
        {
            unitOfWork.ContactUsRepository.Update(contactUs);
            unitOfWork.Save();
        }

        public void DeleteContactUs(int id)
        {
             unitOfWork.ContactUsRepository.Delete(id);
             unitOfWork.Save();
        }

        public IEnumerable<ContactUs> GetContactUs(Expression<Func<ContactUs, bool>> filter = null,
            Func<IQueryable<ContactUs>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.ContactUsRepository.Get(null, null, "");
            return result;
        }
    }
}
