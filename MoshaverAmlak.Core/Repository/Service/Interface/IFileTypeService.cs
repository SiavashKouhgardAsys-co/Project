using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Service.Interface
{
    public interface IFileTypeService
    {
        ReturnEntity_IQueryable<FileType> GetAllFileTypes();
        ReturnEntity<FileType> GetFileTypeById(int id);
        Task<Result> CreateFileType(FileType fileType);
        Task<Result> DeleteFileType(int id);
        Task<Result> EditFileType(FileType fileType);
    }
}
