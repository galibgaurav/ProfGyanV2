using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessDataModel;

namespace IBusinessLayer
{
    public interface IDocumentBL
    {
        Document AddDocument(Document document);
        void DeleteDocument(string id);
        IEnumerable<Document> GetDocument(Expression<Func<Document, bool>> filter = null, Func<IQueryable<Document>, IOrderedQueryable<Document>> orderBy = null, string includeProperties = "");
        Document GetDocument(string id);
        void UpdateDocument(Document document);
    }
}