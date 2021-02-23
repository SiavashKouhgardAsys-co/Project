using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface ITypeOfDocumentService
    {
        ReturnEntity_IQueryable<TypeOfDocument> GetAllTypeOfDocument();
        ReturnEntity<TypeOfDocument> GetTypeOfDocumentById(int id);
        Task<Result> CreateTypeOfDocument(TypeOfDocument typeOfDocument);
        Task<Result> DeleteTypeOfDocument(int id);
        Task<Result> EditTypeOfDocument(TypeOfDocument typeOfDocument);
    }
}
