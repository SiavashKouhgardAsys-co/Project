using System;
using System.Threading.Tasks;
using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class TypeOfDocumentRepository : ITypeOfDocumentRepository
    {
        private readonly IGenericRepository<TypeOfDocument> _typeOfDocumentRepository;
        public TypeOfDocumentRepository(IGenericRepository<TypeOfDocument> typeOfDocumentRepository)
        {
            _typeOfDocumentRepository = typeOfDocumentRepository;
        }

        public ReturnEntity_IQueryable<TypeOfDocument> GetAllTypeOfDocument() => _typeOfDocumentRepository.GetAllEntity();
        public ReturnEntity<TypeOfDocument> GetTypeOfDocumentById(int typeOfDocumentId) => _typeOfDocumentRepository.GetEntityById(typeOfDocumentId);
        public async Task<Result> CreateTypeOfDocument(TypeOfDocument typeOfDocument)
        {
            var entity = await _typeOfDocumentRepository.AddEntity(typeOfDocument);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _typeOfDocumentRepository.SaveChangeAsync();
        }
        public async Task<Result> DeleteTypeOfDocument(int typeOfDocumentId)
        {
            var entity = _typeOfDocumentRepository.DeleteEntityById(typeOfDocumentId);
            if (entity.StatusResult != (int)Result.Status.OK) return entity;
            return await _typeOfDocumentRepository.SaveChangeAsync();
        }
        public async Task<Result> UpdateTypeOfDocument(TypeOfDocument typeOfDocument)
        {
            var entity = GetTypeOfDocumentById(typeOfDocument.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = typeOfDocument.Name;
            var update_entity = _typeOfDocumentRepository.UpdateEntity(entity.Entity);
            if (update_entity.StatusResult != (int)Result.Status.OK) return update_entity;
            return await _typeOfDocumentRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _typeOfDocumentRepository?.Dispose();
        }
    }
}
