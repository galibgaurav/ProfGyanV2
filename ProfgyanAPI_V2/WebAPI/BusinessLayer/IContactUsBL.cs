using System.Collections.Generic;
using DataModel;

namespace BusinessLayer
{
    public interface IContactUsBL
    {
        ContactUs AddContactUs(ContactUs contactUs);
        void DeleteContactUs(int id);
        IEnumerable<ContactUs> GetContactUs();
        ContactUs GetContactUs(int id);
        int UpdateContactUs(ContactUs contactUs);
    }
}