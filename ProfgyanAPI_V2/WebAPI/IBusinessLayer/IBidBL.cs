using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IBidBL
    {
        Bid AddBid(Bid bid);
        void DeleteBid(int id);
        IEnumerable<Bid> GetBid(Expression<Func<Bid, bool>> filter = null, Func<IQueryable<Bid>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Bid GetBid(int id);
        void UpdateBid(Bid bid);
    }
}