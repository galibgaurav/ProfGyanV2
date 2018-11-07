using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface ICommonDetailBL
    {
        CommonDetail AddCommonDetail(CommonDetail commonDetail);
        void DeleteCommonDetail(int id);
        IEnumerable<CommonDetail> GetCommonDetail(Expression<Func<CommonDetail, bool>> filter = null, Func<IQueryable<CommonDetail>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        CommonDetail GetCommonDetail(int id);
        void UpdateCommonDetail(CommonDetail commonDetail);
    }
}