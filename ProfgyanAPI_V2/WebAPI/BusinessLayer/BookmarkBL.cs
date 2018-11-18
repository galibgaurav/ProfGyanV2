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
    public class BookmarkBL : IBookmarkBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public BookMark GetBookMark(string id)
        {
            return unitOfWork.BookMarkRepository.GetByID(id);
        }

        public BookMark AddBookMark(BookMark bookMark)
        {
            var result = unitOfWork.BookMarkRepository.Insert(bookMark);
            unitOfWork.Save();
            return result;
        }

        public void UpdateBookMark(BookMark bookMark)
        {
            unitOfWork.BookMarkRepository.Update(bookMark);
            unitOfWork.Save();
        }

        public void DeleteBookMark(string id)
        {
            unitOfWork.BookMarkRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<BookMark> GetBid(Expression<Func<BookMark, bool>> filter = null,
            Func<IQueryable<BookMark>, IOrderedQueryable<BookMark>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.BookMarkRepository.Get(null, null, "");
            return result;
        }
    }
}
