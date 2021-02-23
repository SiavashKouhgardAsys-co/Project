using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Class
{
    public class TypeOfDocumentService : ITypeOfDocumentService
    {
        private readonly ITypeOfDocumentRepository _typeOfDocument;
        public TypeOfDocumentService(ITypeOfDocumentRepository typeOfDocument)
        {
            _typeOfDocument = typeOfDocument;
        }

        public ReturnEntity_IQueryable<TypeOfDocument> GetAllTypeOfDocument() => _typeOfDocument.GetAllTypeOfDocument();

        public ReturnEntity<TypeOfDocument> GetTypeOfDocumentById(int id) => _typeOfDocument.GetTypeOfDocumentById(id);
        public async Task<Result> CreateTypeOfDocument(TypeOfDocument typeOfDocument) => await _typeOfDocument.CreateTypeOfDocument(typeOfDocument);
        public async Task<Result> DeleteTypeOfDocument(int id) => await _typeOfDocument.DeleteTypeOfDocument(id);

        public async Task<Result> EditTypeOfDocument(TypeOfDocument typeOfDocument) => await
            _typeOfDocument.UpdateTypeOfDocument(typeOfDocument);
    }
}
