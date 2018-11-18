using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IChatBL
    {
        Chat AddChat(Chat chat);
        void DeleteChat(string id);
        IEnumerable<Chat> GetChat(Expression<Func<Chat, bool>> filter = null, Func<IQueryable<Chat>, IOrderedQueryable<Chat>> orderBy = null, string includeProperties = "");
        Chat GetChat(string id);
        void UpdateChat(Chat chat);
    }
}