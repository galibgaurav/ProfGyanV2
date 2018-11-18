using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IBidBL
    {
        Bid AddBid(Bid bid);
        void DeleteBid(string id);
        IEnumerable<Bid> GetBid(Expression<Func<Bid, bool>> filter = null, Func<IQueryable<Bid>, IOrderedQueryable<Bid>> orderBy = null, string includeProperties = "");
        Bid GetBid(string id);
        void UpdateBid(Bid bid);
    }
}