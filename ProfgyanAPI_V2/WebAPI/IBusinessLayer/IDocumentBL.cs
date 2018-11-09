using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace BusinessLayer
{
    public interface IDocumentBL
    {
        Document AddDocument(Document document);
        void DeleteDocument(int id);
        IEnumerable<Document> GetDocument(Expression<Func<Document, bool>> filter = null, Func<IQueryable<Document>, IOrderedQueryable<string>> orderBy = null, string includeProperties = "");
        Document GetDocument(int id);
        void UpdateDocument(Document document);
    }
}