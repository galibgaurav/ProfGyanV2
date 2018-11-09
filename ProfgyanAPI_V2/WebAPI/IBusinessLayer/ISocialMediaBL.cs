using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface ISocialMediaBL
    {
        SocialMedia AddSocialMedia(SocialMedia socialMedia);
        void DeleteSocialMedia(int id);
        IEnumerable<SocialMedia> GetSocialMedia(Expression<Func<SocialMedia, bool>> filter = null, Func<IQueryable<SocialMedia>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        SocialMedia GetSocialMedia(int id);
        void UpdateSocialMedia(SocialMedia socialMedia);
    }
}