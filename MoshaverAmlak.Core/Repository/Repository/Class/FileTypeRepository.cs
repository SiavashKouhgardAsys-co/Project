using MoshaverAmlak.Core.Repository.Repository.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Class
{
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly IGenericRepository<FileType> _fileTypeRepository;
        public FileTypeRepository(IGenericRepository<FileType> fileTypeRepository)
        {
            _fileTypeRepository = fileTypeRepository;
        }

        public ReturnEntity_IQueryable<FileType> GetAllFileTypes() => _fileTypeRepository.GetAllEntity();
        public ReturnEntity<FileType> GetFileTypeById(int id) => _fileTypeRepository.GetEntityById(id);

        public async Task<Result> CreateFileType(FileType fileType)
        {
            var entity = _fileTypeRepository.AddEntity(fileType);
            if (entity.Status != (int)Result.Status.OK) return await entity;
            return await _fileTypeRepository.SaveChangeAsync();
        }

        public async Task<Result> DeleteFileType(int id)
        {
            var entity = _fileTypeRepository.DeleteEntityById(id);
            if (entity.StatusResult != (int)Result.Status.OK)  return entity;
            return await _fileTypeRepository.SaveChangeAsync();
        }

        public async Task<Result> EditFileType(FileType fileType)
        {
            var entity = GetFileTypeById(fileType.Id);
            if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
            entity.Entity.Name = fileType.Name;
            var updateEntity = _fileTypeRepository.UpdateEntity(entity.Entity);
            if (updateEntity.StatusResult != (int)Result.Status.OK) return updateEntity;
            return await _fileTypeRepository.SaveChangeAsync();
        }

        public void Dispose()
        {
            _fileTypeRepository?.Dispose();
        }
    }
}
