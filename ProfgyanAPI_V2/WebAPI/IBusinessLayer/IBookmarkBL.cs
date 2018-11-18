using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IBookmarkBL
    {
        BookMark AddBookMark(BookMark bookMark);
        void DeleteBookMark(string id);
        IEnumerable<BookMark> GetBid(Expression<Func<BookMark, bool>> filter = null, Func<IQueryable<BookMark>, IOrderedQueryable<BookMark>> orderBy = null, string includeProperties = "");
        BookMark GetBookMark(string id);
        void UpdateBookMark(BookMark bookMark);
    }
}