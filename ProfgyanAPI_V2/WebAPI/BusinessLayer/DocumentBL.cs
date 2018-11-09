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
    public class DocumentBL : IDocumentBL
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public Document GetDocument(int id)
        {
            return unitOfWork.DocumentRepository.GetByID(id);
        }

        public Document AddDocument(Document document)
        {
            var result = unitOfWork.DocumentRepository.Insert(document);
            unitOfWork.Save();
            return result;
        }

        public void UpdateDocument(Document document)
        {
            unitOfWork.DocumentRepository.Update(document);
            unitOfWork.Save();
        }

        public void DeleteDocument(int id)
        {
            unitOfWork.DocumentRepository.Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<Document> GetDocument(Expression<Func<Document, bool>> filter = null,
            Func<IQueryable<Document>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "")
        {
            var result = unitOfWork.DocumentRepository.Get(null, null, "");
            return result;
        }
    }
}

