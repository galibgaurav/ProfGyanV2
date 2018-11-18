using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ICommonDetailBL
    {
        CommonDetail AddCommonDetail(CommonDetail commonDetail);
        void DeleteCommonDetail(string id);
        IEnumerable<CommonDetail> GetCommonDetail(Expression<Func<CommonDetail, bool>> filter = null, Func<IQueryable<CommonDetail>, IOrderedQueryable<CommonDetail>> orderBy = null, string includeProperties = "");
        CommonDetail GetCommonDetail(string id);
        void UpdateCommonDetail(CommonDetail commonDetail);
    }
}