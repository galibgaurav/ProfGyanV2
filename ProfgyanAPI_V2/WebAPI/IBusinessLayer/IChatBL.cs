using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IChatBL
    {
        Chat AddChat(Chat chat);
        void DeleteChat(int id);
        IEnumerable<Chat> GetChat(Expression<Func<Chat, bool>> filter = null, Func<IQueryable<Chat>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Chat GetChat(int id);
        void UpdateChat(Chat chat);
    }
}