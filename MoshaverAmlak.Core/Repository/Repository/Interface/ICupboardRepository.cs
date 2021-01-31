using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoshaverAmlak.Core.Repository.Repository.Interface
{
    interface ICupboardRepository : IDisposable
    {
        ReturnEntity_IQueryable<Cupboard> GetAllCupboard();
        ReturnEntity<Cupboard> GetCupboardById(int cubBoardId);

        Task<Result> CreateCupboard(Cupboard cupboard);
        Task<Result> DeleteCupboardById(int cupboardId);
        Task<Result> EditCupboard(Cupboard cupboard);

    }
}
