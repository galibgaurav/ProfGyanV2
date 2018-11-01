using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModel;

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
             return unitOfWork.ContactUsRepository.Insert(contactUs);
        }

        public int UpdateContactUs(ContactUs contactUs)
        {
            return unitOfWork.ContactUsRepository.Update(contactUs);
        }

        public void DeleteContactUs(int id)
        {
             unitOfWork.ContactUsRepository.Delete(id);
        }

        public IEnumerable<ContactUs> GetContactUs(Expression<Func<ContactUs, bool>> filter = null,
            Func<IQueryable<ContactUs>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.ContactUsRepository.Get(null, null, "");
            return result;
        }
    }
}
