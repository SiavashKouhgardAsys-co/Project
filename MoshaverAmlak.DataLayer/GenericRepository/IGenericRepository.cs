using System;
using MoshaverAmlak.DataLayer.Entity;

namespace MoshaverAmlak.DataLayer.GenericRepository
{
    public interface IGenericRepository<T> : IDisposable  where T : BaseEntity
    {
    }
}
