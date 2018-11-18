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
    public class CommonDetailBL : ICommonDetailBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CommonDetail GetCommonDetail(string id)
        {
            return unitOfWork.CommonDetailRepository.GetByID(id);
        }

        public CommonDetail AddCommonDetail(CommonDetail commonDetail)
        {
            var result = unitOfWork.CommonDetailRepository.Insert(commonDetail);
            unitOfWork.Save();
            return result;
        }

        public void UpdateCommonDetail(CommonDetail commonDetail)
        {
            unitOfWork.CommonDetailRepository.Update(commonDetail);
            unitOfWork.Save();
        }

        public void DeleteCommonDetail(string id)
        {
            unitOfWork.CommonDetailRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<CommonDetail> GetCommonDetail(Expression<Func<CommonDetail, bool>> filter = null,
            Func<IQueryable<CommonDetail>, IOrderedQueryable<CommonDetail>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.CommonDetailRepository.Get(null, null, "");
            return result;
        }
    }
}

