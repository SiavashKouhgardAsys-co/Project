using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.DataLayer.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // GET DATE
        public ReturnEntity_IQueryable<T> GetAllEntity()
        {
            ReturnEntity_IQueryable<T> returnEntity = new ReturnEntity_IQueryable<T>();
            try
            {
                returnEntity.Entity = _dbSet.Where(x => x.IsDelete == false).AsQueryable();
                returnEntity.Result = Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                returnEntity.Result = Result.GenerateResult(Result.Status.Failed);
            }
            return returnEntity;
        }
        public ReturnEntity<T> GetEntityById(int entityId)
        {
            ReturnEntity<T> returnEntity = new ReturnEntity<T>();
            try
            {
                returnEntity.Entity = _dbSet.FirstOrDefault(x => x.Id == entityId && x.IsDelete == false);
                returnEntity.Result = Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                returnEntity.Result = Result.GenerateResult(Result.Status.Failed);
            }
            return returnEntity;
        }
        public ReturnEntity_IQueryable<T> GetAllEntityByOtherColumn(Expression<Func<T , bool>> exception)
        {
            ReturnEntity_IQueryable<T> returnEntity = new ReturnEntity_IQueryable<T>();
            try
            {
                returnEntity.Entity = _dbSet.Where(exception).AsQueryable();
                returnEntity.Result = Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                returnEntity.Result = Result.GenerateResult(Result.Status.Failed);
            }
            return returnEntity;
        }
        public ReturnEntity<T> GetEntityByOtherColumn(Expression<Func<T, bool>> exception)
        {
            ReturnEntity<T> returnEntity = new ReturnEntity<T>();
            try
            {
                returnEntity.Entity = _dbSet.Where(exception).FirstOrDefault();
                returnEntity.Result = Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                returnEntity.Result = Result.GenerateResult(Result.Status.Failed);
            }
            return returnEntity;
        }   

        // CREATE
        public Result AddEntity(T entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.LastUpdate = entity.CreateDate;
                _dbSet.Add(entity);
                return Result.GenerateResult(Result.Status.Failed);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }
        public Result AddRangeEntity(List<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.CreateDate = DateTime.Now;
                    item.LastUpdate = item.CreateDate;
                }
                _dbSet.AddRange(entities);
                return Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }

        // UPDATE
        public Result UpdateEntity(T entity)
        {
            try
            {
                entity.LastUpdate = DateTime.Now;
                _dbSet.Update(entity);
                return Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }
        public Result UpdateRangeEntity(List<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.LastUpdate = DateTime.Now;
                }
                _dbSet.UpdateRange(entities);
                return Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }

        // DELETE
        public Result DeleteEntity(T entity)
        {
            try
            {
                entity.IsDelete = true;
                return UpdateEntity(entity);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }
        public Result DeleteRangeEntity(List<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.IsDelete = true;
                }
                return UpdateRangeEntity(entities);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }
        public Result DeleteEntityById(int entityId)
        {
            try
            {
                var entity = GetEntityById(entityId);
                if (entity.Result.StatusResult != (int)Result.Status.OK) return entity.Result;
                return DeleteEntity(entity.Entity);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }

        // SAVE CHANGE
        public async Task<Result> SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                var message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }
        public Result SaveChange()
        {
            try
            {
                _context.SaveChanges();
                return Result.GenerateResult(Result.Status.OK);
            }
            catch (Exception e)
            {
                var message = e.Message;
                return Result.GenerateResult(Result.Status.Failed);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
