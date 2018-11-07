using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IContactUsBL
    {
        ContactUs AddContactUs(ContactUs contactUs);

        void DeleteContactUs(int id);

        IEnumerable<ContactUs> GetContactUs(
            Expression<Func<ContactUs, bool>> filter = null,
            Func<IQueryable<ContactUs>, IOrderedQueryable<string>> orderBy = null,
            string includeProperties = "");

        ContactUs GetContactUs(int id);

        void UpdateContactUs(ContactUs contactUs);
    }
}