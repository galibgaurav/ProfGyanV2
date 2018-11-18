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
    public class RatingBL : IRatingBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Rating GetRating(string id)
        {
            return unitOfWork.RatingRepository.GetByID(id);
        }

        public Rating AddRating(Rating rating)
        {
            var result = unitOfWork.RatingRepository.Insert(rating);
            unitOfWork.Save();
            return result;
        }

        public void UpdateRating(Rating rating)
        {
            unitOfWork.RatingRepository.Update(rating);
            unitOfWork.Save();
        }

        public void DeleteRating(string id)
        {
            unitOfWork.RatingRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Rating> GetAppointment(Expression<Func<Rating, bool>> filter = null,
            Func<IQueryable<Rating>, IOrderedQueryable<Rating>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.RatingRepository.Get(null, null, "");
            return result;
        }
    }
}
