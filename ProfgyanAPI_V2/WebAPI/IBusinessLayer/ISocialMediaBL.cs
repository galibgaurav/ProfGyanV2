using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface ISocialMediaBL
    {
        SocialMedia AddSocialMedia(SocialMedia socialMedia);
        void DeleteSocialMedia(string id);
        IEnumerable<SocialMedia> GetSocialMedia(Expression<Func<SocialMedia, bool>> filter = null, Func<IQueryable<SocialMedia>, IOrderedQueryable<SocialMedia>> orderBy = null, string includeProperties = "");
        SocialMedia GetSocialMedia(string id);
        void UpdateSocialMedia(SocialMedia socialMedia);
    }
}