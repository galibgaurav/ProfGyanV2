using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModel;

namespace BusinessLayer
{
    public class ContactUsBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<ContactUs> GetContactUs()
        {
            var result=unitOfWork.ContactUsRepository.Get(null, null, "");
            return result;
        }

        public ContactUs GetContactUs(int id)
        {
            return unitOfWork.ContactUsRepository.GetByID(id);
        }

        public void AddContactUs()
        {

        }

        public void UpdateContactUs()
        {
        }

        public void DeleteContactUs(int id)
        {
        }
    }
}
