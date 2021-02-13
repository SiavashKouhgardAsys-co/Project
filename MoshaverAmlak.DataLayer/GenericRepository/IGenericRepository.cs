using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.DataLayer.GenericRepository
{
    public interface IGenericRepository<T> : IDisposable  where T : BaseEntity
    {
        ReturnEntity_IQueryable<T> GetAllEntity();
        ReturnEntity<T> GetEntityById(int entityId);
        ReturnEntity_IQueryable<T> GetAllEntityByOtherColumn(Expression<Func<T, bool>> exception);
        ReturnEntity<T> GetEntityByOtherColumn(Expression<Func<T, bool>> exception);
        Result AddEntity(T entity);
        Result AddRangeEntity(List<T> entities);
        Result UpdateEntity(T entity);
        Result UpdateRangeEntity(List<T> entities);
        Result DeleteEntity(T entity);
        Result DeleteRangeEntity(List<T> entities);
        Result DeleteEntityById(int entityId);
        
        Task<Result> SaveChangeAsync();
        Result SaveChange();
    }
}
