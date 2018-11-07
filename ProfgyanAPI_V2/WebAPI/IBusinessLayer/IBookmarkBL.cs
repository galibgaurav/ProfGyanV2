using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IBookmarkBL
    {
        BookMark AddBookMark(BookMark bookMark);
        void DeleteBookMark(int id);
        IEnumerable<BookMark> GetBid(Expression<Func<BookMark, bool>> filter = null, Func<IQueryable<BookMark>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        BookMark GetBookMark(int id);
        void UpdateBookMark(BookMark bookMark);
    }
}