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
    public class FileTypeService : IFileTypeService
    {
        private readonly IFileTypeRepository _fileType;
        public FileTypeService(IFileTypeRepository fileType)
        {
            _fileType = fileType;
        }

        public ReturnEntity_IQueryable<FileType> GetAllFileTypes() => _fileType.GetAllFileTypes();

        public ReturnEntity<FileType> GetFileTypeById(int id) => _fileType.GetFileTypeById(id);
        public async Task<Result> CreateFileType(FileType fileType) => await _fileType.CreateFileType(fileType);
        public async Task<Result> DeleteFileType(int id) => await _fileType.DeleteFileType(id);

        public async Task<Result> EditFileType(FileType fileType) => await
            _fileType.EditFileType(fileType);
    }
}
