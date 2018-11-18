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
    public class SocialMediaBL : ISocialMediaBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public SocialMedia GetSocialMedia(string id)
        {
            return unitOfWork.SocialMediaRepository.GetByID(id);
        }

        public SocialMedia AddSocialMedia(SocialMedia socialMedia)
        {
            var result = unitOfWork.SocialMediaRepository.Insert(socialMedia);
            unitOfWork.Save();
            return result;
        }

        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            unitOfWork.SocialMediaRepository.Update(socialMedia);
            unitOfWork.Save();
        }

        public void DeleteSocialMedia(string id)
        {
            unitOfWork.SocialMediaRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<SocialMedia> GetSocialMedia(Expression<Func<SocialMedia, bool>> filter = null,
            Func<IQueryable<SocialMedia>, IOrderedQueryable<SocialMedia>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.SocialMediaRepository.Get(null, null, "");
            return result;
        }
    }
}

