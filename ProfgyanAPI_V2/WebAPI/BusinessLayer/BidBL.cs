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
    public class BidBL : IBidBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Bid GetBid(int id)
        {
            return unitOfWork.BidRepository.GetByID(id);
        }

        public Bid AddBid(Bid bid)
        {
            var result = unitOfWork.BidRepository.Insert(bid);
            unitOfWork.Save();
            return result;
        }

        public void UpdateBid(Bid bid)
        {
            unitOfWork.BidRepository.Update(bid);
            unitOfWork.Save();
        }

        public void DeleteBid(int id)
        {
            unitOfWork.BidRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Bid> GetBid(Expression<Func<Bid, bool>> filter = null,
            Func<IQueryable<Bid>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.BidRepository.Get(null, null, "");
            return result;
        }
    }
}
