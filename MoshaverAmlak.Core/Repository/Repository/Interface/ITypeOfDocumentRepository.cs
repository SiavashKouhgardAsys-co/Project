using System;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    public interface ITypeOfDocumentRepository : IDisposable
    {
        ReturnEntity_IQueryable<TypeOfDocument> GetAllTypeOfDocument();
        ReturnEntity<TypeOfDocument> GetTypeOfDocumentById(int typeOfDocumentId);
        Task<Result> CreateTypeOfDocument(TypeOfDocument typeOfDocument);
        Task<Result> DeleteTypeOfDocument(int typeOfDocumentId);
        Task<Result> UpdateTypeOfDocument(TypeOfDocument typeOfDocument);
    }
}
