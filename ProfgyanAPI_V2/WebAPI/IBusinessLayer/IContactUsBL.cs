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

        void DeleteContactUs(string id);

        IEnumerable<ContactUs> GetContactUs(
            Expression<Func<ContactUs, bool>> filter = null,
            Func<IQueryable<ContactUs>, IOrderedQueryable<ContactUs>> orderBy = null,
            string includeProperties = "");

        ContactUs GetContactUs(string id);

        void UpdateContactUs(ContactUs contactUs);
    }
}