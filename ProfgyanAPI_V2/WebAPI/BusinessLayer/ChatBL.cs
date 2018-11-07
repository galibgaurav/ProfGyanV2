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
    public class ChatBL : IChatBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Chat GetChat(int id)
        {
            return unitOfWork.ChatRepository.GetByID(id);
        }

        public Chat AddChat(Chat chat)
        {
            var result = unitOfWork.ChatRepository.Insert(chat);
            unitOfWork.Save();
            return result;
        }

        public void UpdateChat(Chat chat)
        {
            unitOfWork.ChatRepository.Update(chat);
            unitOfWork.Save();
        }

        public void DeleteChat(int id)
        {
            unitOfWork.ChatRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Chat> GetChat(Expression<Func<Chat, bool>> filter = null,
            Func<IQueryable<Chat>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.ChatRepository.Get(null, null, "");
            return result;
        }
    }
}
